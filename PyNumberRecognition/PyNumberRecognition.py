import cv2
from PyIN import PyIN as IN
from flask import Flask, jsonify, request
import json
import numpy as np
from urllib.parse import urlparse, parse_qs

app = Flask(__name__)
rec = IN()

@app.route('/car-number', methods=['GET'])
def get_number_car():
    
    url = request.url
    parsed_url = urlparse(url)
    params = parse_qs(parsed_url.query)
    data = params['file'][0]
    #img = np.asarray(data, dtype=np.uint8)
    img = cv2.imread(data)

    image = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY) 

    number = rec.get_number_car(image)
    
    return number

if __name__ == '__main__':
    app.run(port=5002)