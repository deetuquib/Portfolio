import re

from gtts import gTTS


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
INVALID_CHARACTERS = "[^a-z\s]+"  # any non alpha or whitespace characters


def stringToICAO(letter, mapping):
    """This function converts each letter to its ICAO equivalent."""

    return mapping.get(letter, "")


if __name__ == "__main__":
    raw_name = str(input("Please enter your name: "))

    # clean the name
    # ` Diana Jean   C.   Tuquib  ` will become `diana jean c tuquib`
    name = " ".join(re.sub(INVALID_CHARACTERS, "", raw_name.lower()).split())
    # convert each letter in the cleaned name to its ICAO equivalent
    # `diana jean c tuquib` will become
    # `delta india alpha november alpha  juliett echo alpha november  charlie  tango uniform quebec uniform india bravo`
    text = " ".join([stringToICAO(letter, ICAO_MAPPING) for letter in name])

    # generate the TTS audio
    audio = gTTS(text=text)
    # convert `diana jean c tuquib` to `diana_jean_c_tuquib.mp3` and save
    audio.save(f"{name.replace(' ', '_')}.mp3")
