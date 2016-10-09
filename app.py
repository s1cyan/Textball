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
    json_length = json.load(json_file)['players']
    json_file.close()

    if json_length < 9:
        queue(number, message_body)
    else:
        update(number, message_body)


def queue(number, message):
    json_file = open("queue.json", "r")
    data = json.load(json_file)
    data['players'][number] = message
    json_file.close()

    json_file = open("queue.json", "w+")
    json.dump(data, json_file)
    json_file.close()


def update(number, message):
    json_file = open("queue.json", "r")
    data = json.load(json_file)
    if data['players'].get(number) is not None:
        data['players'].update({number: message})
    json_file.close()

    json_file = open("queue.json", "w+")
    json.dump(data, json_file)
    json_file.close()


def queue_or_update(number, message):
    # Get the json file and load the data
    json_file = open("queue.json", "r")
    data = json.load(json_file)
    json_file.close()

    written_file = open("queue.json", "r+")

    if len(data['players']) < 9 and number not in data['players'].keys():
        print "Add"
        data['players'][number] = message
    elif len(data['players']) < 9 and number in data['players'].keys():
        print "Update"
        data['players'].update({number: message})
        json.dump(data, written_file)
        written_file.close()


if __name__ == '__main__':
    app.run(port=5000)
