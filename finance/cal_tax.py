from flask import Blueprint, render_template
from Util import Util

cal_tax = Blueprint('cal_tax', __name__, url_prefix='/tax')

@cal_tax.route('/')
def tax_index():
    return render_template('finance/tax_index.html')
