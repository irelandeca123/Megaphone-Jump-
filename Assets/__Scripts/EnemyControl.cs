using UnityEngine;

public class EnemyControl : MonoBehaviour {

    //Enemy speed
    float speed;

	void Start () {
        //speed initialised at the start to 2
        speed = 2f;
	}
	
	void Update () {

        //creates position equal to vector
        //sets the position equal to to the x and y axis and sets the speed multiplayed by the time.
        //then spawns the enemy
        // and if the enemy is spawned at the wrong place it is destoyed

        Vector2 position = transform.position;
        
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
        

	}
   
    //if the enemy collides with player or bullet destroy it
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "Test") || (col.tag == "Bullet")){
            Destroy(gameObject);
        }
    }



}
