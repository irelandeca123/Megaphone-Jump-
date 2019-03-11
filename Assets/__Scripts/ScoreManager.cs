using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //text on screen displaying score 
    public Text textScore;
    public static int Score;

	void Start () {
        //setting score to 0
        textScore.text = "Score: 0";
	}
	
    //updating the score (platform)  and if the current score is bigger than highest score saved previously then store the new score
	public void UpdateScore (int score) {
        textScore.text = "Score: " + (score/3) * 10;

        Score = (score / 3) * 10;
        if ((score/3) * 10  > PlayerPrefs.GetInt("HighScore", 0))
        {
          PlayerPrefs.SetInt("HighScore", (score / 3) * 10);         
        }
        
	}
}
