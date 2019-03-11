using UnityEngine;

public class Platform : MonoBehaviour {

    //For the other controls that i had (using arrows and space bar)

     //sets the jump force to 10
    public float jumpForce = 10f;

    //when colided get the rigidbody component add velocity and jump force
    private void OnCollisionEnter2D(Collision2D collision)
    {

       if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }


      
    }

}
