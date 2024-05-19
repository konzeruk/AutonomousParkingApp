from NNSegmentation import NNSegmentation
import pytesseract
import cv2

class PyIN:
    def __init__(self):
        self.nn = NNSegmentation()
        pytesseract.pytesseract.tesseract_cmd = r'C:\Program Files\Tesseract-OCR\tesseract.exe'
        
    def get_number_car(self, img):
        
        yolo_coords = self.nn.get_labels(img)
        bbox_coords = self.__yolo_to_bbox(yolo_coords, len(img[0]), len(img))

        cropped_image = self.__crop_image(img, bbox_coords)

        thresh = 125
        cropped_image_gray = cv2.threshold(cropped_image, thresh, 255, cv2.THRESH_BINARY)[1]
        
        return pytesseract.image_to_string(
            cropped_image_gray,
            config='--oem 3 --psm 10 -c tessedit_char_whitelist=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789')
    
    def __yolo_to_bbox(self, yolo_coords, image_width, image_height):
        """
        Преобразует координаты ограничивающей рамки из формата YOLO в формат ограничивающих прямоугольников (bounding box).

        Args:
            yolo_coords (tuple): Кортеж с координатами ограничивающей рамки в формате YOLO (x_center, y_center, width, height).
            image_width (int): Ширина изображения.
            image_height (int): Высота изображения.

        Returns:
            tuple: Кортеж с координатами ограничивающей рамки в формате (x_min, y_min, x_max, y_max).
        """
        x_center, y_center, width, height = yolo_coords
        x_min = (x_center - width / 2) * image_width
        y_min = (y_center - height / 2) * image_height
        x_max = x_min + width * image_width
        y_max = y_min + height * image_height
        return (x_min, y_min, x_max, y_max)
    
    def __crop_image(self, image, bbox_coords):
        """
        Вырезает область изображения согласно ограничивающему прямоугольнику.

        Args:
            image (numpy.ndarray): Исходное изображение.
            bbox_coords (tuple): Кортеж с координатами ограничивающей рамки в формате (x_min, y_min, x_max, y_max).

        Returns:
            numpy.ndarray: Вырезанная область изображения.
        """
        x_min, y_min, x_max, y_max = bbox_coords
        cropped_image = image[int(y_min):int(y_max), int(x_min):int(x_max)]
        return cropped_image