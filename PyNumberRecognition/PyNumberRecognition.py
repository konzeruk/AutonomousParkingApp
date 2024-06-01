import cv2
from PyIN import PyIN as IN
from flask import Flask, jsonify, request
import json

app = Flask(__name__)

@app.route('/car-number', methods=['GET'])
def get_number_car():
    
    data = request.get_json()
    img = json.loads(data)    

    rec = IN()

    image = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY) 

    number = rec.get_number_car(image)
    
    return number

if __name__ == '__main__':
    app.run(port=5002)