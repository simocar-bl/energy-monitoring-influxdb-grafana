using System;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using EasyModbus;

namespace Progetto_tesi
{
    public partial class Form1 : Form
    {
        // --- Configurazione ---------------------------------------------------------
        private const string PortaCom = "COM4";
        private const int ModbusUnitId = 5;
        private const int ModbusBaudrate = 9600;
        private const int IntervalloLetturaMs = 60010;

        private const string FileValoriCasuali = "random_values.csv";
        private const string FileValoriImpianto = "Val_impianto.csv";
        private const string IntestazioneCasuali = "Timestamp,Temp_batt,Temp_inv,Temp_amb,Umidita,Vel_vento";
        private const string IntestazioneImpianto = "Timestamp,current,power";
        // ----------------------------------------------------------------------------

        private readonly Timer myTimer = new Timer();
        private readonly ModbusClient modEnergy = new ModbusClient(PortaCom);
        private readonly Random random = new Random();

        private double temp_batt;
        private double temp_inv;
        private double temp_amb;
        private double umidita;
        private double vel_vento;
        private double current;
        private double power;

        public Form1()
        {
            InitializeComponent();

            myTimer.Interval = IntervalloLetturaMs;
            myTimer.Tick += MyTimer_Tick2;
        }

        // ============================ Modalità 1: valori casuali ============================

        private void PulsNumCas_Click(object sender, EventArgs e)
        {
            GeneraValoriCasuali();

            textBox.Text = "La data attuale è: " + Timestamp() + "\r\n\r\n" +
                           "Temperatura batteria: " + temp_batt.ToString("F2") + "\r\n" +
                           "Temperatura strumento che trasforma DC -> AC: " + temp_inv.ToString("F2") + "\r\n" +
                           "Temperatura del fluido che torna dagli utilizzatori: " + temp_amb.ToString("F2") + "\r\n" +
                           "Umidità: " + umidita.ToString("F2") + "\r\n" +
                           "Velocità del vento: " + vel_vento.ToString("F2") + "\r\n";
        }

        private void PulsSalvVal_Click(object sender, EventArgs e)
        {
            if (temp_batt == 0 && temp_inv == 0 && temp_amb == 0 && umidita == 0 && vel_vento == 0)
            {
                MessageBox.Show("Genera prima i valori casuali.");
                return;
            }

            string riga = string.Join(",", Timestamp(), F2(temp_batt), F2(temp_inv), F2(temp_amb), F2(umidita), F2(vel_vento));
            string percorso = PercorsoDati(FileValoriCasuali);
            AggiungiRigaCsv(percorso, IntestazioneCasuali, riga);

            MessageBox.Show($"File CSV scritto con successo a (percorso): {percorso}");
        }

        /// <summary>
        /// Genera 50 punti di prova (uno al minuto, terminando adesso) con un andamento "a camminata casuale",
        /// così il grafico su Grafana risulta leggibile. Sono dati SIMULATI, non misure reali.
        /// </summary>
        private void PulsDemo_Click(object sender, EventArgs e)
        {
            const int numeroPunti = 50;

            DateTimeOffset fine = DateTimeOffset.UtcNow;
            double[] valori = new double[5];
            for (int k = 0; k < valori.Length; k++)
            {
                valori[k] = 20 + random.NextDouble() * 60; // punto di partenza tra 20 e 80
            }

            StringBuilder csv = new StringBuilder();
            string percorso = PercorsoDati(FileValoriCasuali);
            if (!File.Exists(percorso))
            {
                csv.AppendLine(IntestazioneCasuali);
            }

            for (int i = numeroPunti - 1; i >= 0; i--)
            {
                for (int k = 0; k < valori.Length; k++)
                {
                    valori[k] += (random.NextDouble() - 0.5) * 8;       // piccola variazione
                    valori[k] = Math.Max(0, Math.Min(100, valori[k]));  // resta tra 0 e 100
                }

                string timestamp = fine.AddMinutes(-i).ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
                csv.AppendLine(string.Join(",", timestamp, F2(valori[0]), F2(valori[1]), F2(valori[2]), F2(valori[3]), F2(valori[4])));
            }

            File.AppendAllText(percorso, csv.ToString());

            textBox.Text = $"Generati {numeroPunti} punti di prova (uno al minuto, fino a ora)." + "\r\n" +
                           "Ora premi \"Carica su InfluxDB\".";
        }

        private void PulsInfluxdb_Click(object sender, EventArgs e)
        {
            CaricaSuInflux(PercorsoDati(FileValoriCasuali), mostraEsito: true);
        }

        private void PulsCanval_Click(object sender, EventArgs e)
        {
            try
            {
                string percorso = PercorsoDati(FileValoriCasuali);

                if (File.Exists(percorso))
                {
                    File.Delete(percorso);
                    MessageBox.Show("Il file CSV è stato cancellato con successo.");
                }
                else
                {
                    MessageBox.Show("Il file CSV non esiste.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante la cancellazione del file: {ex.Message}");
            }
        }

        // ============================ Modalità 2: impianto reale (Modbus RTU) ============================

        private void Puls_Coll_Modbus_RTU_Click(object sender, EventArgs e)
        {
            try
            {
                modEnergy.UnitIdentifier = ModbusUnitId;
                modEnergy.Baudrate = ModbusBaudrate;
                modEnergy.Parity = System.IO.Ports.Parity.None;
                modEnergy.StopBits = System.IO.Ports.StopBits.One;
                modEnergy.ConnectionTimeout = 500;

                modEnergy.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}");
            }
        }

        private void Puls_Auto_Click(object sender, EventArgs e)
        {
            myTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myTimer.Stop();
        }

        private void MyTimer_Tick2(object sender, EventArgs e)
        {
            try
            {
                string timestamp = Timestamp();

                // Registri input 6..13: corrente nei primi due (6,7), potenza negli ultimi due (12,13)
                int[] lettura_dati_Modbus = modEnergy.ReadInputRegisters(6, 8);
                current = Math.Round(IEEE754_converter((UInt16)lettura_dati_Modbus[0], (UInt16)lettura_dati_Modbus[1]), 2);
                power = Math.Round(IEEE754_converter((UInt16)lettura_dati_Modbus[6], (UInt16)lettura_dati_Modbus[7]), 2);

                textBox1.Text = "La data attuale è: " + timestamp + "\r\n\r\n" +
                                "Corrente: " + current.ToString("F2") + "\r\n" +
                                "Potenza: " + power.ToString("F2") + "\r\n";

                string riga = string.Join(",", timestamp, F2(current), F2(power));
                string percorso = PercorsoDati(FileValoriImpianto);
                AggiungiRigaCsv(percorso, IntestazioneImpianto, riga);

                CaricaSuInflux(percorso, mostraEsito: false);
            }
            catch (Exception ex)
            {
                // Se la lettura fallisce (es. cavo scollegato) fermo l'acquisizione automatica
                myTimer.Stop();
                MessageBox.Show($"Acquisizione interrotta: {ex.Message}");
            }
        }

        /// <summary>
        /// Converte due registri Modbus a 16 bit (word alta + word bassa) in un float IEEE754 a 32 bit.
        /// </summary>
        private Double IEEE754_converter(UInt16 parolaAlta, UInt16 parolaBassa)
        {
            Int16 esponente;
            Double mantissa;
            Double numero1;
            double temp;
            UInt32 mask;
            UInt32 partenza_mantissa;
            UInt32 temporaneo;
            UInt32 segno;
            byte i;

            //parolaAlta = 0x4367; //MSW
            //parolaBassa = 0xB333; //LSW
            esponente = (Int16)((parolaAlta & 0x7F80) >> 7);
            esponente = (Int16)(esponente - 127);

            segno = (UInt16)((parolaAlta & 0x8000) >> 15);

            parolaAlta = (UInt16)(parolaAlta & 127); //isolo i bit della word alta della mantissa
            temporaneo = (UInt32)(parolaAlta);
            temporaneo = temporaneo << 16;
            partenza_mantissa = (UInt32)(parolaBassa) + temporaneo;
            mask = 4194304;
            mantissa = 1;
            for (i = 0; i < 23; i++)
            {
                temp = (partenza_mantissa & mask) >> (22 - i);
                mantissa = mantissa + temp * Math.Pow(2, -(i + 1));
                mask = mask >> 1;
            }
            numero1 = mantissa * Math.Pow(2, esponente);
            //mask = 0;
            //se il segno è negativo inverto il numero
            if (segno == 1)
                numero1 = 0 - numero1;
            return numero1;
        }

        // ============================ Funzioni di supporto ============================

        private void GeneraValoriCasuali()
        {
            temp_batt = random.NextDouble() * 100;
            temp_inv = random.NextDouble() * 100;
            temp_amb = random.NextDouble() * 100;
            umidita = random.NextDouble() * 100;
            vel_vento = random.NextDouble() * 100;
        }

        /// <summary>Timestamp UTC nel formato richiesto dallo script Python.</summary>
        private static string Timestamp()
        {
            return DateTimeOffset.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        }

        /// <summary>Numero con 2 decimali e punto come separatore (indipendente dalla lingua di Windows).</summary>
        private static string F2(double valore)
        {
            return valore.ToString("F2", CultureInfo.InvariantCulture);
        }

        /// <summary>I CSV vengono salvati accanto all'eseguibile.</summary>
        private static string PercorsoDati(string nomeFile)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeFile);
        }

        /// <summary>Aggiunge una riga al CSV, scrivendo prima l'intestazione se il file non esiste.</summary>
        private static void AggiungiRigaCsv(string percorso, string intestazione, string riga)
        {
            StringBuilder csv = new StringBuilder();
            if (!File.Exists(percorso))
            {
                csv.AppendLine(intestazione);
            }
            csv.AppendLine(riga);
            File.AppendAllText(percorso, csv.ToString());
        }

        /// <summary>Cerca Cart_Per_P\Caric_Influx.py risalendo dalla cartella dell'eseguibile (bin\Debug -> radice progetto).</summary>
        private static string TrovaScriptPython()
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            while (dir != null)
            {
                string candidato = Path.Combine(dir.FullName, "Cart_Per_P", "Caric_Influx.py");
                if (File.Exists(candidato))
                {
                    return candidato;
                }
                dir = dir.Parent;
            }
            throw new FileNotFoundException("Script Cart_Per_P\\Caric_Influx.py non trovato.");
        }

        /// <summary>Lancia lo script Python che carica il CSV su InfluxDB.</summary>
        private void CaricaSuInflux(string csvPercorso, bool mostraEsito)
        {
            try
            {
                string script = TrovaScriptPython();

                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "python";
                start.Arguments = $"\"{script}\" \"{csvPercorso}\"";
                start.UseShellExecute = false;        // niente shell: necessario per reindirizzare l'output
                start.RedirectStandardOutput = true;  // permette al C# di leggere ciò che stampa Python
                start.RedirectStandardError = true;   // idem per gli errori
                start.CreateNoWindow = true;

                using (Process process = Process.Start(start))
                {
                    string result = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (mostraEsito && !string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show(result);
                    }
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}");
            }
        }

        private void Puls_esc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
