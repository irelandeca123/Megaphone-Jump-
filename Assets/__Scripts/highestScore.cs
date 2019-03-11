using UnityEngine;
using UnityEngine.UI;

public class highestScore : MonoBehaviour {

    //text to display the high score
    public Text highScore;
    
    //setting the text to the score by getting the high score thats stored using playerprefs 
    void Start() {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

}
