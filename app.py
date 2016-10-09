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
    queue_or_update(number, message_body)


def queue_or_update(number, message):
    # with open("queue.json", "r+") as json_file:
    #     data = json.load(json_file)
    #     data['players'].update({ number : message })
    #     json.dump(data, json_file)
    json_file = open("queue.json", "r")
    data = json.load(json_file)
    json_file.close()

    print len(data['players'])

    if len(data['players']) < 8:
        data['players'].update({number: message})
        written_file = open("queue.json", "r+")
        json.dump(data, written_file)
        written_file.close()


if __name__ == '__main__':
    app.run(port=5000)
