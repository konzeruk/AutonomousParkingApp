import cv2
from PyIN import PyIN as IN

def get_number_car(img):
    rec = IN()

    image = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY) 

    number = rec.get_number_car(image)
    
    return number