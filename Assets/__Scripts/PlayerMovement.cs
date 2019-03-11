using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //assigning all the variables , game objects booleans etc
    //importing the scoreManager script
    private bool jump = false;
    public GameObject PlayerBulletGo;
    public GameObject BulletPosition;
    public GameManager gameManager;

    public GameObject micVolume; //microphone volume object
    private float moveSpeed; //moving speed
    private float micVolumeTest; //microphone volume
    Rigidbody2D rb; //rigidbody
    float dirX; //used for acceleramoter
    float moveSpeed1 = 0.3f; //moving speed
    private Vector3 gravity; //gravity
    public ScoreManager scoreManager; //importing script

    private bool isGrounded;

    public Transform feetPos;       //this variable will store reference to transform from where we will create a circle
    public LayerMask whatIsGround;  //ground
    public float circleRadius;      //radius of circle



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //get reference to 	Rigidbody2D component
    }
    void Update()
    {
        //if the user clicks on the screen then bullet gets called and drawn (player shoots)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GameObject bullet = (GameObject)Instantiate(PlayerBulletGo);
            bullet.transform.position = BulletPosition.transform.position;
        }

        //sets the isGrounded to the feet position , circule radius and the ground so when the player is fully grounded on platform
        isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius, whatIsGround);
       
        //accelerometer input 
        dirX = Input.acceleration.x * moveSpeed1;
      
        //moving speed for jumping (force)
        moveSpeed = micVolume.GetComponent<MicrophoneInput>().loudness * 0.01f;

        //loudness of microphone without *0.01f which is force for jumping on previous one
        micVolumeTest = micVolume.GetComponent<MicrophoneInput>().loudness;
       
        //transform the x (axis accelerometer)
        transform.position = new Vector3(transform.position.x + dirX, transform.position.y, 0);

        //if the volume of microphone is between 10 and 50 allow the jump 
        if (micVolumeTest > 10f && micVolumeTest < 50f && isGrounded == true)
        {  
            //jump is true
            jump = true;
        }

        //if the jump is true
        if (jump == true)
        {    
            //set it to the microphone volume (y axis) so the player jumps then after that make the jump false and is grounded false as 
            //the player is in the air
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, 0);
            jump = false;
            isGrounded = false;
        }

    }

    //if the player is on the platform and is detected then add to the score in score manager
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            scoreManager.UpdateScore((int)transform.position.y);
        }
    }
    //if the enemy touches the player then the player is dead and send it over to the gamaManager (game over)
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
