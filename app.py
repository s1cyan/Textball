from flask import Flask, request
from twilio import twiml
import json

app = Flask(__name__)


@app.route("/")
def index():
    return


@app.route("/receive", methods=['POST'])
def receive_sms():
    number = request.form['From']
    message_body = request.form['Body']

    print "From: " + number + " | Message: " + message_body

    json_file = open("queue.json", "r")
    data = json.load(json_file)
    json_length = len(data['players'])
    json_file.close()

    print json_length
    if json_length < 8:
        queue(number, message_body)
    else:
        update(number, message_body)


def queue(number, message):
    json_file = open("queue.json", "r")
    data = json.load(json_file)
    data['players'].update({number : message})
    json_file.close()

    json_file = open("queue.json", "w+")
    json.dump(data, json_file)
    json_file.close()


def update(number, message):
    json_file = open("queue.json", "r")
    data = json.load(json_file)
    print "Is none? " + str(data['players'].get(number))
    if data['players'].get(number) is not None:
        data['players'].update({number: message})
    json_file.close()

    json_file = open("queue.json", "w+")
    json.dump(data, json_file)
    json_file.close()


if __name__ == '__main__':
    app.run(port=5000)
