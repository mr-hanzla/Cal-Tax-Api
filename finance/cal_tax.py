from flask import Blueprint, render_template
from Util import Constant

cal_tax = Blueprint('cal_tax', __name__, url_prefix=f'{Constant.API_V1}/finance')

@cal_tax.route('/')
def tax_index():
    return render_template('finance/tax_index.html')
