test_string = []
for i in range(1,145):
    test_string.append(i)

def convert_strings_to_floats(test_string):
	output_array = []
	for element in test_string:
		converted_float = float(element)
		output_array.append(converted_float)
	return output_array

output_array = convert_strings_to_floats(test_string)
print(output_array)



