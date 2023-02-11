from flask import Blueprint
from Util import Util, Constant

person = Blueprint('person', __name__, url_prefix=f'{Constant.API_V1}/person')

@person.route('/greet/<name>')
def greet(name):
    return Util.get_in_h_tag(f'<h1>Assalam o Alaikum, {name.capitalize()}!</h1>', 1)
