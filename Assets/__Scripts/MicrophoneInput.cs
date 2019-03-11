using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MicrophoneInput : MonoBehaviour {

    //assigns the adiomixergroup so it can be seperated 
    //text 
    //hides loudness and sensitivity 

    public AudioMixerGroup mixedGroupMicrophone;
    public Text value;
    [HideInInspector]
    public  float loudness = 300;
    public static float sensitivity = 100f;

    void Start()
    {

        GetComponent<AudioSource>().outputAudioMixerGroup = mixedGroupMicrophone; //set the output for the audio mixer group
        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 10, 44100); //start the loop
        GetComponent<AudioSource>().loop = true; // Set the AudioClip to loop
        while (!(Microphone.GetPosition("") > 0))
        {
        } // Wait until the recording has started
        GetComponent<AudioSource>().Play(); // Play the audio source!
    }

    void Update()
    {
        //get the sensitivity thats set using the slider in microphoneInput script
        //set the loudness to be the average volume multiplied by the sensitivity and then set the value to text
        sensitivity = PlayerPrefs.GetFloat("Sens");
        loudness = GetAveragedVolume() * sensitivity;
        value.text = sensitivity.ToString();
    }


    float GetAveragedVolume()
    {   //calculate the the average volume
        //float of 256 that stores data
        //get the audio source and compare the data recorded 
        float[] data = new float[256];
        float a = 0;
        GetComponent<AudioSource>().GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    } 
}

















