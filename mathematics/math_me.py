from flask import Blueprint, abort, request, jsonify
from jinja2 import TemplateNotFound

math_me_bp = Blueprint('math_me', __name__, url_prefix='/math')

@math_me_bp.route('/')
def show():
    return "Yayyyy, bluepring is working fine!"

@math_me_bp.route('/circle/area')
def area_of_circle():
    radius = int(request.args.get('r', default=0))
    if radius <= 0:
        return abort(404, 'Abey yaaar! radius ki value +ve rakh bro... be +ve :)')
    return jsonify(f'Area of circle = Pi*{radius}^2 = {3.14*(radius**2)}')


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
