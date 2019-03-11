using UnityEngine;

public class MicrophoneSettings : MonoBehaviour {
    
    //sets the sensitivity using the slider from the options menu and stores it on playerprefs
    public void SetSensitivity(float newSens)
    {
        PlayerPrefs.SetFloat("Sens",newSens);
        
    }

}
