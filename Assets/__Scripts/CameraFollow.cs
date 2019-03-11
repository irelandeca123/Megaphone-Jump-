using UnityEngine;


public class CameraFollow : MonoBehaviour {

    //Assigning all the variables for the camera,speed
    //follow player and timer
    public GameManager gameManager;
    public Transform timerImage;
    private float speed;
    private float speedMultiple = .5f;
    private Vector3 targetPosition;
    public Transform target;
    private float distance;
    private float startLimmit = 0f;
    private float maxDistanceBeforeLose = 5f;
    private float timer;

    void Start()
    {
        //setting the timer to 0 at the start method so its the first thing that the program executes
        timer = 0;
    }
    void LateUpdate()
    {
        //set the start distance 
        distance = target.position.y - transform.position.y;

        //if the position of player is less than start limit
        if (target.position.y < startLimmit)
            return;

        //if the distance is less than max distance before losing 
        if (distance < -maxDistanceBeforeLose)
        {
            //set game = over call game over in game manager script
            gameManager.GameOver();

        }
         
        //if distance is more than 1
        else if (distance > 1)
        {
            //target the character (camera)
            targetPosition = new Vector3(0, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, distance * Time.deltaTime);
        }
        else
        {
            //target the character (camera)
            targetPosition = new Vector3(0, transform.position.y + speed, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        }

        //set the timer + increase speed depending on timer and speed multiple declared at the start
        //and then rotate the image depending on the speed (timerImage)
        timer += Time.deltaTime;
        speed = (1 + (timer) / 60) * speedMultiple;
        timerImage.rotation = Quaternion.Euler(0, 0, -((timer) % 60) * 360 / 60f);
    }
}
