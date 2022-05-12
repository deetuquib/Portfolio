The *International Civil Aviation Organization (ICAO) alphabet* assigns code words to the letters of the English alphabet acrophonically (Alfa for A, Bravo for B, etc.) so that critical combinations of letters (and numbers) can be pronounced and understood by those who transmit and receive voice messages by radio or telephone regardless of their native language, especially when the safety of navigation or persons is essential. Here is a Python dictionary covering one version of the ICAO alphabet:


```python
ICAO_MAPPING = {
    "a": "alpha",
    "b": "bravo",
    "c": "charlie",
    "d": "delta",
    "e": "echo",
    "f": "foxtrot",
    "g": "golf",
    "h": "hotel",
    "i": "india",
    "j": "juliett",
    "k": "kilo",
    "l": "lima",
    "m": "mike",
    "n": "november",
    "o": "oscar",
    "p": "papa",
    "q": "quebec",
    "r": "romeo",
    "s": "sierra",
    "t": "tango",
    "u": "uniform",
    "v": "victor",
    "w": "whiskey",
    "x": "x-ray",
    "y": "yankee",
    "z": "zulu",
}
```

Your task is to write a program that will convert a text file that contains your name to its ICAO equivalent and then have the computer speak the ICAO equivalent using the google Text To Speech module `gTTS`. You then save the resulting text to speech into a .`mp3` file.

You have to create a function `stringToICAO` that receives a string as an argument as well as the dictionary and that returns a string which is the original string converted to ICAO.

The main program reads the text file, calls the function `stringToICAO` , uses `gTTS` to create the speech and finally saves the result into a .mp3 file.

Upload to brightspace the program **lab11.py** as well as the resulting **mp3** file.

**Reference for gTTS:**

(note install it using `pip3` not `pip`)

`https://www.geeksforgeeks.org/convert-text-speech-python/?ref=lbp`
