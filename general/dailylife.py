from flask import Blueprint, render_template

dailylife = Blueprint('dailylife', __name__, url_prefix='/dailylife')


@dailylife.route('/stopwatch')
def greet():
    return render_template('general/stopwatch.html')
