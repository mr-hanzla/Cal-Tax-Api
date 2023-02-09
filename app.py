import flask
from flask import request, jsonify
from mathematics import math_me
from general import person
from Util import Util

app = flask.Flask(__name__)
app.config["DEBUG"] = True

app.register_blueprint(math_me.math_me_bp)

app.register_blueprint(person.person)

@app.route('/', methods=['GET'])
def home():
    return '''<h1>Gee aya no! 😊</h1>
<p>Saare available routes dekhny k liye IP k aage '/routes' add kardo</p>'''


@app.route('/header')
def header_testing():
    Util.cshow(request.headers)
    return 'OK, Header sahi kaam kar rha hy.....'


@app.route('/owner', methods=['GET'])
def owner():
    return '''<h1>Hanzy 😎 </h1>'''


@app.route('/<name>')
def greet(name):
    return f'''<h1>Salam, {name.capitalize()}. Kia haal chaal hy?</h1>'''


@app.route('/routes')
def routes():
    return jsonify(Util.get_routes())


@app.route('/api/v1/resources/books/all', methods=['GET'])
def api_all():
    return jsonify(Util.get_books())


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
