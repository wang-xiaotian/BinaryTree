
<!-- Title Image Starts-->
[![FVCproductions](https://user-images.githubusercontent.com/56288794/94039010-06cb9a00-fd7c-11ea-9877-e61000f1c1d4.PNG)](http://fvcproductions.com)
<!-- Title Image Ends-->

<!-- Title Starts-->
# Binary Tree Solutions
> The client sends a JSON object “string_to_cut”; <br />
> The server parses that JSON object, extract every third alphanumeric letter and return anther JSON object "return_string" to client.<br />  
<!-- Title Ends-->

<!-- Badges Starts-->
[![made-with-python](https://img.shields.io/badge/Made%20with-Python-1f425f.svg)](https://www.python.org/)
[![microsoft-powerpoint](https://img.shields.io/badge/MICROSOFT-POWERPOINT-green)](http://microsoft.org)
[![shields-io](https://img.shields.io/badge/Shields-IO-orange)](http://shields.org)
[![flask-python](https://img.shields.io/badge/FLASK-PYTHON-blue)](http://shields.org)
[![recordit-rec](https://img.shields.io/badge/Recordit-REC-red)](http://shields.org)
<!-- Badges Ends-->

<!-- spacer starts -->
---
<!-- spacer ends -->

<!-- DEMO starts -->
***Check it out!***
![demo GIF by GIF MAKER](https://user-images.githubusercontent.com/56288794/88509309-a1367980-cf95-11ea-9c9d-b58eb657662d.gif)

---
<!-- DEMO ENDS -->

## Table of Contents
  - [Installation](#installation)
    - [Server Setup](#server-setup)
    - [Client](#client)
  - [Screenshot](#screenshot)
  - [Code Sample](#code)
  - [Challenges](#challenges)
  - [Resource](#resource)
  - [License](#license)


---
## Installation

### Server Setup

> <a href="https://flask.palletsprojects.com/en/1.1.x/installation" target="_blank"> Install Flask package first </a> <br />

```shell
$ sudo pip install Flask
```
> Step 1:
```
C:\> set FLASK_APP = server.py
```
> Step 1 (Unix):
```
$ export FLASK_APP = server.py
```
> Step 2 (Option 1)
```
> flask run
```
> Step 2 (Option 2)
```
> python server.py
```

### Client
```shell
> curl -X POST HTTP://127.0.0.1:5000/test --header "Content-Type: application/json" --data {\"string_to_cut\":\"EXAMPLE_STRING\"}
```

---

## Screenshot
![demo GIF by GIF MAKER](https://user-images.githubusercontent.com/56288794/88518703-c501bb80-cfa5-11ea-92a5-67ba192951b1.gif)
---
## Code

---
```python
# Response to POST request
# Accept a JSON argument with key 'string_to_cut'
# Parse string and only retain every third letter from input argument
# Return string with key 'return_string'
@app.route('/test', methods=['POST'])
def lyft_test():
    return_string = "Unexpected Error: \n (Windows Users): Please execute command line \n curl -X POST HTTP://127.0.0.1:5000/test --header \"Content-Type: application/json\" --data {\\\"string_to_cut\\\":\\\"STRING\\\"}"
    try: # throw exceptions if not JSON format
        data = request.get_json()
        # verify input argument 'string_to_cut'
        # ONLY execute cut_string_Alphanumeric
        # WHEN key = 'string_to_cut'
        string_to_cut = None
        if 'string_to_cut' in data:
            string_to_cut = data['string_to_cut']
            return_string = cut_string_Alphanumeric(string_to_cut)
        else:
            return_string = "Oops! KEY 'string_to_cut' DOES NOT EXIST IN YOUR ARGUMENT! PLEASE TYPE AGAIN."
    except:
        print(return_string)
    return return_string
```



```python
# Extract every third letter from input string
# e.g. cut_string_Alphanumeric("abcedfg") returns "cf"
# special cases:
#   1. empty string
#   2. length of string may cause overflow, veryfy before access to input_string[index]
#   3. only return alphanumeric letters
#   4. what if input string has backslash -- WORKING ON IT
def cut_string_Alphanumeric(input_string):
    return_string = ""
    index = 0 # index of string[]
    count = 1 # number of alphanumeric letters
    while (index < len(input_string)):
        if input_string[index].isalnum():
            if (count%3 == 0): #retain every 3rd alphanumeric letters
                return_string += input_string[index]
            count+=1
        index+=1
    return jn.dumps({'return_string':return_string}, indent = 4) # return json object
```
---
## Challenges

> Working on it: Input String contains spaces <br/>
> Working on it: Deploy this wep application on AWS or Azure server <br/>
> REDO: Demo GIF <br />

---

## Resource
<a href="https://www.w3schools.com/" target="_blank"> W3 School Python </a> <br />
<a href="https://docs.python.org/3.8/tutorial/" target="_blank"> Python Documentation & Tutorial </a> <br />
<a href="https://www.freecodecamp.org/" target="_blank"> FreeCodeCamp </a> <br />
<a href="https://flask.palletsprojects.com/en/1.1.x/" target="_blank"> Flask </a> <br />

---
## License
> Oops! Coming soon !!!

---
