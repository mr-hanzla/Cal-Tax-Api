from flask import Blueprint

person = Blueprint('person', __name__, url_prefix='/person')

@person.route('/greet/<name>')
def greet(name):
    return f'<h1>Assalam o Alaikum, {name.capitalize()}!</h1>'
