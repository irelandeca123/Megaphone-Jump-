using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //animator for the game over menu when player is dead,
    //other variables and game object initiliaised

    public Animator panelGameOverAnim;
    public Text gameScore;
    public Text menuScore;
    public static bool GameIsPause = false;
    public GameObject pauseMenu;
    public GameObject resumeMenu;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Text soundValue;

    //game over method,when called disables player object (destoys or hides it )opens the animation ,
    //displays the score (txt)
    public void GameOver()
    {
       
       GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;    
       panelGameOverAnim.SetTrigger("Open");
       menuScore.text = gameScore.text;
       gameScore.gameObject.SetActive(false);
    }


    //method to reset screne or load it again
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Resume()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        Time.timeScale = 1f;
        GameIsPause = false;
        resumeMenu.SetActive(false);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPause = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        resumeMenu.SetActive(true);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(true);
    
    }

}
