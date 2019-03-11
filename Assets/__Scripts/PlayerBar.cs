using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour {
    //assigns all the variables,gameobjects hide inspector 
    // in order to hide the floats
    MicrophoneInput microphoneInput;
    public GameObject micVolume;

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    public float health = 100;
    public float health1 = 0;

    public Image jumpBar;

    public void Update()
    {
        //get the microphone input component , add health1 variable equal to the loudness and fill it so it shows in the game 
       microphoneInput = GetComponent<MicrophoneInput>();
       health1= micVolume.GetComponent<MicrophoneInput>().loudness;
       jumpBar.fillAmount = health1 / 100f;
    }


}
