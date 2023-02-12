from flask import (
    Blueprint,
    render_template,
    request,
    abort,
    jsonify
)
from Util import (
    Constant,
    Util,
    tax_util
)

cal_tax = Blueprint('cal_tax', __name__,
                    url_prefix=f'{Constant.API_V1}/finance')


@cal_tax.route('/')
def tax_index():
    return render_template('finance/tax_index.html')


@cal_tax.route('/cal-tax')
def calculate_tax_on_monthly_income():
    try:
        monthly_income = request.args['monthly-income']
        monthly_income = int(monthly_income)

        if monthly_income < 0:
            raise TypeError(
                'Yaaaar! itne ghareeb k monthly income 0 se bhi nichay?')

    except TypeError as t:
        return abort(400, t)
    except ValueError as v:
        return abort(400, 'O BHAI..!! salary mei numbers likhny hein!')
    except:
        return abort(404, 'URL k aage ? laga k \'monthly-income\' add karo')
    Util.cshow(int(monthly_income))

    yearly_income = monthly_income * 12

    tax_percentage, additional_yearly_tax_amount, yearly_taxable_income = tax_util.get_tax_values_against_yearly_income(
        yearly_income)

    yearly_tax_amount = tax_util.get_yearly_tax_amount(
        tax_percentage, additional_yearly_tax_amount, yearly_taxable_income)

    yearly_income_after_tax = yearly_income - yearly_tax_amount

    return jsonify({
        'monthly_income': monthly_income,
        'yearly_income': yearly_income,
        'yearly_income_after_tax': yearly_income_after_tax,
        'yearly_tax_amount': yearly_tax_amount,
        'yearly_taxable_income': yearly_taxable_income,
        'additional_yearly_tax_amount': additional_yearly_tax_amount,
        'tax_percentage': tax_percentage
    })
