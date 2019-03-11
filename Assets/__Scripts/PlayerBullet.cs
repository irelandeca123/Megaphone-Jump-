using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    
    //set the variables and import scoreManager

    float speed;
    public ScoreManager scoreManager;

    void Start () {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {

        //position of the bullet and direction 
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //destroy it 
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}

    //on trigger with enemy then destroy enemy 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "Enemy") || (col.tag == "Bullet"))
        {

            Destroy(gameObject);
            
        }
    }

}
