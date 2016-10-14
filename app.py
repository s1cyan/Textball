from flask import Flask, request
from twilio import twiml
import sqlite3
import json

app = Flask(__name__)

relationship_dict = {}
path = "Assets/Resources/queue.json"

@app.route("/")
def index():
    return


@app.route("/receive", methods=['POST'])
def receive_sms():
    number = request.form['From']
    message_body = request.form['Body']

    print "From: " + number + " | Message: " + message_body

    json_file = open(path, "r")
    data = json.load(json_file)
    json_length = len(data['players'][0])
    json_file.close()

    print json_length
    queue(number, message_body)
    update(number, message_body)


def queue(number, message):
    if len(relationship_dict.keys()) < 8 and relationship_dict.get(number) is None:
        print "queue"
        relationship_dict[number] = "x" + str(len(relationship_dict.keys()))

        json_file = open(path, "r")
        data = json.load(json_file)
        data['players'][0].update({relationship_dict[number]: str(message).lower()})
        json_file.close()

        json_file = open(path, "w+")
        json.dump(data, json_file)
        json_file.close()


def update(number, message):
    print "update"
    json_file = open(path, "r")
    data = json.load(json_file)
    print "Is none? " + str(data['players'][0].get(number))
    if data['players'][0].get(relationship_dict[number]) is not None:
        data['players'][0].update({relationship_dict[number]: str(message).lower()})
    json_file.close()

    json_file = open(path, "w+")
    json.dump(data, json_file)
    json_file.close()


if __name__ == '__main__':
    relationship_dict.clear()
    app.run(port=5000)
