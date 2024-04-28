# Generate column names skipping every three columns
column_names = [str(i) for i in range(1, 145) if i % 3 != 0]

# Sample data arrays for demonstration
data_arrays = [
    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],   # Sample data for column 1
    # Add sample data arrays for other columns here
]

# Initialize a dictionary to store column data
columns_data = {name: [] for name in column_names}

# Append data to corresponding columns
for i, col_name in enumerate(column_names):
    columns_data[col_name] = data_arrays[i]

# Print the appended data for each column
for col_name, col_data in columns_data.items():
    print(f"Column {col_name}: {col_data}")
