import flask
from flask import request, jsonify
from mathematics import math_me

app = flask.Flask(__name__)
app.config["DEBUG"] = True

app.register_blueprint(math_me.math_me_bp)

# Create some test data for our catalog in the form of a list of dictionaries.
books = [
    {'id': 0,
     'title': 'A Fire Upon the Deep',
     'author': 'Vernor Vinge',
     'first_sentence': 'The coldsleep itself was dreamless.',
     'year_published': '1992'},
    {'id': 1,
     'title': 'The Ones Who Walk Away From Omelas',
     'author': 'Ursula K. Le Guin',
     'first_sentence': 'With a clamor of bells that set the swallows soaring, the Festival of Summer came to the city Omelas, bright-towered by the sea.',
     'published': '1973'},
    {'id': 2,
     'title': 'Dhalgren',
     'author': 'Samuel R. Delany',
     'first_sentence': 'to wound the autumnal city.',
     'published': '1975'}
]


@app.route('/', methods=['GET'])
def home():
    return '''<h1>Distant Reading Archive</h1>
<p>A prototype API for distant reading of science fiction novels.</p>'''


@app.route('/owner', methods=['GET'])
def owner():
    return '''
    <h1>Hanzy B-) </h1>
    '''

@app.route('/<name>')
def greet(name):
    return f'''
    <h1>Salam, {name.capitalize()}. Kia haal chaal hy?</h1>

    '''

@app.route('/routes')
def routes():
    a = [
        '/<name>',
        '/owner',
        '/api/v1/resources/books/all',
        '/math'
        ]
    return jsonify(a)

# A route to return all of the available entries in our catalog.
@app.route('/api/v1/resources/books/all', methods=['GET'])
def api_all():
    return jsonify(books)


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
