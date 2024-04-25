from joblib import load
import json
import sys

if len(sys.argv) < 2:
    print("Usage: python script.py <parameter>")
    sys.exit(1)

parameter = sys.argv[1]
print("Parameter:", parameter)
# load_pnt = json.loads("{\n    \"data\": [[0.02614065, 0.04852969, 0.08149   , 0.1155533 , 0.10190149,0.1160985 , 0.0941752 , 0.09838805, 0.11096662, 0.08678643,0.09318216, 0.10614858, 0.08470459, 0.0889438 , 0.11663967,0.13486271]]\n}")
load_pnt = json.loads(parameter)
print(json.dumps(load_pnt))
print(load_pnt["data"])

# Load the model from file
knn_classifier_loaded = load('classifier.joblib')
out = knn_classifier_loaded.predict(load_pnt["data"])
# out = knn_classifier_loaded.predict([[0.02614065, 0.04852969, 0.08149   , 0.1155533 , 0.10190149,0.1160985 , 0.0941752 , 0.09838805, 0.11096662, 0.08678643,0.09318216, 0.10614858, 0.08470459, 0.0889438 , 0.11663967,0.13486271]])
data = {
    "output": out.tolist()
}
# print(out)
json_string = json.dumps(data)
print(json_string)

# Now you can use knn_classifier_loaded for prediction or further analysis
