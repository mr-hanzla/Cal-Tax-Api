import os
from flask import Blueprint, abort
from jinja2 import TemplateNotFound

math_me_bp = Blueprint('math_me', __name__,url_prefix='/math')

@math_me_bp.route('/')
def show():
    return "Yayyyy, bluepring is working fine!"

