import math


def get_tax_values_against_yearly_income(yearly_income):
    tax_percentage = 0
    taxable_amount = 0
    additional_tax_amount = 0

    if yearly_income <= 600000:
        # 0%
        tax_percentage = 0.0
        taxable_amount = 0.0
        additional_tax_amount = 0.0

    elif 600000 < yearly_income <= 1200000:
        # 2.5% of the amount exceeding Rs. 600,000
        tax_percentage = 2.5
        additional_tax_amount = 0.0
        taxable_amount = yearly_income - 600000

    elif 1200000 < yearly_income <= 2400000:
        # Rs. 15,000 + 12.5% of the amount exceeding Rs. 1,200,000
        tax_percentage = 12.5
        additional_tax_amount = 15000
        taxable_amount = yearly_income - 1200000

    elif 2400000 < yearly_income <= 3600000:
        # Rs. 165,000 + 20% of the amount exceeding Rs. 2,400,000
        tax_percentage = 20.0
        additional_tax_amount = 165000
        taxable_amount = yearly_income - 2400000

    elif 3600000 < yearly_income <= 6000000:
        # Rs. 405,000 + 25% of the amount exceeding Rs. 3,600,000
        tax_percentage = 25.0
        additional_tax_amount = 405000
        taxable_amount = yearly_income - 3600000

    elif 6000000 < yearly_income <= 12000000:
        # Rs. 1,005,000 + 32.5% of the amount exceeding Rs. 6,000,000
        tax_percentage = 32.5
        additional_tax_amount = 1005000
        taxable_amount = yearly_income - 6000000

    elif yearly_income > 12000000:
        # Rs. 2,955,000 + 35% of the amount exceeding Rs. 12,000,000
        tax_percentage = 35.0
        additional_tax_amount = 2955000
        taxable_amount = yearly_income - 12000000

    return tax_percentage, additional_tax_amount, taxable_amount


def get_yearly_tax_amount(tax_percentage, additional_yearly_tax_amount, yearly_taxable_income):
    return math.ceil(additional_yearly_tax_amount + (yearly_taxable_income * (tax_percentage / 100)))

