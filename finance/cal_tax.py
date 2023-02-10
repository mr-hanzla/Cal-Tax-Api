from flask import Blueprint, render_template

cal_tax = Blueprint('cal_tax', __name__, url_prefix='/tax')

cal_tax.route('/')
def tax_index():
    return render_template('tax_index.html')
