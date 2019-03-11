using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //Create a game object for the enemy
    //score,spawning intervals , count down and initilaises scores 50 , 100 .. equal to 0

    public GameObject Enemy;
    private static int score;
    public float spawnInterval = 3f;
    public float currentSpawnTime = 0;
    public float bigCountdown = 120; // 120 seconds is 2 minutes
    public float currentBigTime = 0;
    private int score50 = 0;
    private int score100 = 0;
    private int score150 = 0;
    private int score200 = 0;
    private int score250 = 0;
    private int score300 = 0;




    void Update()
    {
        //sets score and sets it in scoremanager (Score)
        //sets the spawn the time and ads on +1 timer
        //does the same thing with big time
        
        score = ScoreManager.Score;
        currentSpawnTime += Time.deltaTime;
        currentBigTime += Time.deltaTime;

        //if the current spawn time is bigger or equal to spawn interval number
        if (currentSpawnTime >= spawnInterval)
        {
            //spawn enemys and set the current spawn time to 0
            SpawnEnemy();
            currentSpawnTime = 0;
        }

        //current big tim eis bigger or equal to the big count down 2mins 
        //every 2 mins spawn rate increase
        if (currentBigTime >= bigCountdown)
        {
            // spawnInterval decrease (more enemies)
            // setting the current big time = 0
            spawnInterval -= .1f;
            currentBigTime = 0;
        }       

        //if the score is 50 
        if (score == 50 && score50 == 0)
        {
            spawnInterval -= 1f;
            score50 = 1;
        }


        if (score == 100 && score100 == 0)
        {
            spawnInterval -= 1f;
            score100 = 1;
        }

        if (score == 150 && score150 == 0)
        {
            spawnInterval -= 1f;
            score150 = 1;
        }

        if (score == 200 && score200 == 0)
        {
            spawnInterval -= 1f;
            score200 = 1;
        }

        if (score == 250 && score250 == 0)
        {
            spawnInterval -= 1f;
            score250 = 1;
        }

        if (score == 300 && score300 == 0)
        {
            spawnInterval -= 1f;
            score300 = 1;
        }









    }
    //spawn the enemy, set the min position and max position and spawn the enemy on top of the map going downards
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(Enemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    
    }



}


// ====================================================================================================================
