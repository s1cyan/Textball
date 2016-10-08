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
    write_to_file(number, message_body)

def write_to_file(number, message):
    with open("queue.json", "w") as outfile:
        data = json.dump(
            {
                str(number) : str(message)
            },
            outfile
        )
    
if __name__ == '__main__':
    app.run(port=5000)