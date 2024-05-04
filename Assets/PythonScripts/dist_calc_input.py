from scipy.spatial.distance import euclidean
from joblib import load
import sys

# data_input = "-0.1201486 -0.1741536 0.2131586 -0.2016456 0.538661 -0.6071734 -0.1201486 -0.1741536 0.2131586 -0.2016456 0.538661 -0.6071734 -0.1172899 -0.1491644 0.2062597 -0.2094751 0.02009952 -0.5027335 -0.1298763 -0.1274582 0.2017494 0.03364709 -0.007506758 -0.5911427 -0.1399147 -0.09566674 0.2026727 0.006148934 0.09691022 -0.6183012 -0.1474239 -0.06227571 0.2081763 0.04431798 -0.01735993 -0.4671062 -0.1056881 -0.07538594 0.2324596 -0.2580338 0.4802926 -0.6879542 -0.08981761 -0.04010077 0.2365488 -0.2682443 0.4997962 -0.6798545 -0.07924718 -0.01765989 0.239039 -0.2224301 0.5402135 -0.6454412 -0.08929399 -0.08628528 0.2441962 -0.480843 0.3538043 -0.8016322 -0.06571005 -0.06907193 0.2112341 -0.5972285 -0.05583382 -0.6041317 -0.0731655 -0.08887011 0.1924969 -0.4936267 -0.2301555 -0.340836 -0.07327873 -0.1003658 0.244813 -0.5013164 0.3910627 -0.7709224 -0.05349772 -0.0823484 0.2150769 -0.6505386 0.03805802 -0.6095031 -0.06042459 -0.09600154 0.1925236 -0.6294377 -0.1695022 -0.3893802 -0.08500338 -0.1517563 0.2247681 -0.2333501 0.7203965 -0.5145851 -0.05842854 -0.1166263 0.2406588 -0.2503259 0.6637319 -0.6223035 -0.0377687 -0.09317406 0.2446855 -0.2409461 0.69945 -0.6078206 -0.02282252 -0.07884257 0.2469934 -0.2534859 0.6896081 -0.5885822 -0.1625429 -0.04206274 0.2090325 0.04431798 -0.01735993 -0.4671062 -0.0698515 0.002207324 0.245707 -0.2224301 0.5402135 -0.6454412 -0.08954878 -0.1085827 0.1919759 -0.4936267 -0.2301555 -0.340836 -0.07570545 -0.1139959 0.1842673 -0.6294377 -0.1695022 -0.3893802 -0.008593142 -0.06211302 0.2519901 -0.2534859 0.6896081 -0.5885822"
data_input = sys.argv[1:]
data_list = [float(x) for x in data_input]

def convert_strings_to_floats(test_string):
	output_array = []
	for element in test_string:
		converted_float = float(element)
		output_array.append(converted_float)
	return output_array

output_array = convert_strings_to_floats(data_list)

new_arr = []
# print("data arr=",len(data_list))
# for i in range(0,len(data_list)):
# 	if (i%6 == 0 or i % 6 ==1 or i % 6 ==2):
# 		new_arr.append(data_list[i])
# 	else:
# 		continue
	
new_arr = data_list

start_i = 3
for i in range(3,6):
	del(new_arr[start_i])
	
# filtered_data = [x for x in new_arr if x <= 111.0]

column_names = [int(i) for i in range(1, 55)]

columns_data = {name: [] for name in column_names}

for i, col_name in enumerate(column_names):
   columns_data[col_name] = new_arr[i]

manipulated_data = columns_data
# print(manipulated_data)         #data filtered, removed column that are unnecessary and added key as a column name , the process ends here

# print(len(manipulated_data))

#euclidean distance calculation starts here
data = {}
for i in range(1, len(manipulated_data) // 3 + 1):
    index = i * 3 - 2
    data[i] = (manipulated_data[index], manipulated_data[index + 1], manipulated_data[index + 2])

# print("Data=",data)
distances = {}
for i in range(2, 19):  # Loop from 2 to 18
    distances[1, i] = euclidean(data[1], data[i])

#print(distances)

values = list(distances.values())
print(values)
print(len(values))

knn_classifier_loaded = load('Assets\PythonScripts\classifier.joblib')
out = knn_classifier_loaded.predict([values])

print(out)