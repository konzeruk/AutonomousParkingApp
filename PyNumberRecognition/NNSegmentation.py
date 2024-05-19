import torch
import pathlib

class NNSegmentation:
    def __init__(self):
        pathlib.PosixPath = pathlib.WindowsPath
        self.model = torch.hub.load('yolov5', 'custom', path='last.pt', source='local')
    
    def get_labels(self, img):
        predictes = self.model([img])    
        
        predictes = predictes.xywhn[0]
           
        correct_index_predictes = self.__max_percent(predictes)
        correct_predict = predictes[correct_index_predictes]
        
        labels = []
        for it in range(0, len(correct_predict) - 2):
            labels.append(correct_predict[it].numpy())
        
        return labels
                
    def __max_percent(self, predictes):
        correct_index_predictes = 0
        pred_percent = -1
        
        it = 0
        for predict in predictes:
            current_percent = predict[len(predict) - 2]
            
            if current_percent > pred_percent:
                pred_percent = current_percent
                correct_index_predictes = it
            
            ++it
        return correct_index_predictes
            
    