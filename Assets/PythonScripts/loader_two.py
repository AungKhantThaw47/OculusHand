from joblib import load
import json
import sys

print(sys.argv)
print(len(sys.argv))

if len(sys.argv) < 2:
    print("Usage: python script.py <parameter>")
    sys.exit(1)

d = []
d.append(sys.argv[1])
d.append(float(sys.argv[2]))

print(type(d[0]))
print(d[0])
print(type(d[1]))
print(d[1])

print(d)

print("result:",d)