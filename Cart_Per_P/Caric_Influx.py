"""Carica su InfluxDB Cloud un file CSV generato dall'applicazione C#.

Uso:
    python Caric_Influx.py <percorso_csv>

Configurazione tramite variabili d'ambiente (il token NON va scritto nel codice):
    INFLUX_TOKEN   (obbligatoria)
    INFLUX_URL     (default: https://us-east-1-1.aws.cloud2.influxdata.com)
    INFLUX_ORG     (default: progetto)
    INFLUX_BUCKET  (default: Bucket)
"""
import csv
import os
import sys
from datetime import datetime

from influxdb_client import InfluxDBClient, Point, WritePrecision
from influxdb_client.client.write_api import SYNCHRONOUS

MEASUREMENT = "senso_dati"

url = os.environ.get("INFLUX_URL", "https://us-east-1-1.aws.cloud2.influxdata.com")
org = os.environ.get("INFLUX_ORG", "progetto")
bucket = os.environ.get("INFLUX_BUCKET", "Bucket")
token = os.environ.get("INFLUX_TOKEN")

if len(sys.argv) != 2:
    print("Uso: python Caric_Influx.py <percorso_csv>")
    sys.exit(1)

if not token:
    print("Errore: variabile d'ambiente INFLUX_TOKEN non impostata.")
    sys.exit(1)

percorso_csv = sys.argv[1]

# Lista dei punti: vengono scritti su InfluxDB tutti insieme, in blocco
data_points = []

with open(percorso_csv, mode="r") as file:
    reader = csv.DictReader(file)  # ogni riga diventa un dizionario
    header = reader.fieldnames

    for row in reader:
        try:
            timestamp = datetime.strptime(row["Timestamp"], "%Y-%m-%dT%H:%M:%SZ")
            point = Point(MEASUREMENT).time(timestamp, WritePrecision.MS)
            for key in header[1:]:  # salto "Timestamp", il primo campo
                point = point.field(key, float(row[key]))
            data_points.append(point)
        except KeyError as e:
            print(f"Chiave non trovata: {e}")
        except ValueError as e:
            print(f"Errore di valore: {e}")

if not data_points:
    print("Nessun dato da caricare.")
    sys.exit(0)

with InfluxDBClient(url=url, token=token, org=org) as client:
    write_api = client.write_api(write_options=SYNCHRONOUS)
    write_api.write(bucket=bucket, org=org, record=data_points)
