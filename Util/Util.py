
def cshow(msg):
    print('*'*50)
    print(msg)
    print('*'*50)

def get_books():
    return [
        {
            'id': 0,
            'title': 'A Fire Upon the Deep',
            'author': 'Vernor Vinge',
            'first_sentence': 'The coldsleep itself was dreamless.',
            'year_published': '1992'
        },
        {
            'id': 1,
            'title': 'The Ones Who Walk Away From Omelas',
            'author': 'Ursula K. Le Guin',
            'first_sentence': 'With a clamor of bells that set the swallows soaring, the Festival of Summer came to the city Omelas, bright-towered by the sea.',
            'published': '1973'
        },
        {
            'id': 2,
            'title': 'Dhalgren',
            'author': 'Samuel R. Delany',
            'first_sentence': 'to wound the autumnal city.',
            'published': '1975'
        }
    ]

def get_routes():
    return [
        '/<name>',
        '/owner',
        '/api/v1/resources/books/all',
        '/math',
        '/math/formula/quadratic',
        'math/circle/area',
        '/header'
    ]
