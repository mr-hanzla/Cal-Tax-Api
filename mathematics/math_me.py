import os
from flask import Blueprint, abort, request
from jinja2 import TemplateNotFound

math_me_bp = Blueprint('math_me', __name__,url_prefix='/math')

@math_me_bp.route('/')
def show():
    return "Yayyyy, bluepring is working fine!"


@math_me_bp.route('/formula/quadratic')
def quadratic_formula():
    a = b = c = 0
    a = 5
    try:
        a = request.args['a']
        b = request.args['b']
        c = request.args['c']
    except:
        return abort(404, 'Yaaaar!, bongia na mara karo! [a,b,c] ki values pass karo')

    return 'OK'
