import matplotlib.pyplot as plt
from scipy.fftpack import fft
from scipy.io import wavfile # get the api
import numpy as np
from pydub import AudioSegment
import json
from pprint import pprint
from bisect import bisect_left


def cutsong(ID, starttime,endtime,filename, current_time): #ID should be string
    
    newAudio = AudioSegment.from_wav(filename)
    newAudio = newAudio[(starttime*1000):(endtime*1000)]
    newAudio.export(ID + "-" + filename, format="wav") #Exports to a wav file in the current path.
    

def fftcalc(filename):
    fs, data = wavfile.read(filename) # load the data
    a = data.T
    b = a[0] # this is a two channel soundtrack, I get the first track
    c=[(ele/2**8.)*2-1 for ele in b]
    d = fft(c) # calculate fourier transform (complex numbers list)
    e = len(d)/2  # you only need half of the fft list (real signal symmetry)

    k = np.arange(len(data))
    T = float(len(data))/fs  # where fs is the sampling frequency
    frqLabel = k/T  



    freq = frqLabel[:(e-1)]
    intensity = abs(d[:(e-1)])

 

    dictionary = dict(zip(freq,intensity))
        
    subbass = np.where(freq == (takeClosest(freq,16)))[0]

    print subbass

    bass = np.where(freq == (takeClosest(freq,60)))[0]

    print bass

    bassend = np.where(freq == (takeClosest(freq,1250)))[0]

    print bassend

    mids = np.where(freq == (takeClosest(freq,400)))[0]

    print mids

    highs = np.where(freq == (takeClosest(freq,16000)))[0]

    print highs
       
    

    sub_val = np.mean(intensity[subbass:bass])
    bass_val = np.mean(intensity[bass:bassend])
    mid_val = np.mean(intensity[bassend:mids])
    high_val = np.mean(intensity[mids:highs])
    plt.plot(freq,intensity)
    plt.show()
    return [sub_val,bass_val,mid_val,high_val]



def JSONRead(filename):
    localmap = [[]]
    with open(filename) as data_file:    
        data = json.load(data_file)
    for fragment in data['fragments']:
        localmap.append([fragment['id'], fragment['begin'], fragment['end'], fragment['lines']])
    localmap = localmap[1:-1]
    return localmap





def wordMap(localmap):
    ID = 0;
    wordlevel = [[]]
    for element in localmap:
        wordID = 0
        for word in element[-1][0].split(" "):
            start = wordID*(float(element[2])-float(element[1]))/len(element[-1][0].split(" ")) + float(element[1])
            end = start+(float(element[2])-float(element[1]))/len(element[-1][0].split(" "))
            print start
            wordlevel.append([ID, start, end , word ]) #[ID, starttime, endtime, word]
            wordID = wordID + 1
            ID += 1
    wordlevel = wordlevel [1:-1]
    return wordlevel

def main(jsonfile, wavfile):
    returnarray = [[]]
    current_time = 0
    lyrics = wordMap(JSONRead(jsonfile))
    for lyric in lyrics:
        cutsong(str(lyric[0]), float(lyric[1]), float(lyric[2]), wavfile, current_time)
        current_time += (float(lyric[2])-float(lyric[1]))
    for lyric in lyrics:
        print lyric[0]
        print (fftcalc(str(lyric[0])+"-"+wavfile))
        print "\n"
    return returnarray



def takeClosest(myList, myNumber):
    """
    Assumes myList is sorted. Returns closest value to myNumber.

    If two numbers are equally close, return the smallest number.
    """
    pos = bisect_left(myList, myNumber)
    if pos == 0:
        return myList[0]
    if pos == len(myList):
        return myList[-1]
    before = myList[pos - 1]
    after = myList[pos]
    if after - myNumber < myNumber - before:
       return after
    else:
       return before

print main('Starboy_map.json', 'The_Weeknd_Starboy.wav')
