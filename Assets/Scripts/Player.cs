using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    //speed player moves left and ride
    public float speed = 1;
    //sound when player eats good food
    public AudioClip goodSound;
    //sound when eats bad food
    public AudioClip badSound;
    //if player eats too many bad foods it dies
    private bool isDead = false;

    //star appears when a good food is eaten
    public GameObject star;
    //x appears when junk eaten
    public GameObject x;

    public static float vegScore;
    public static float fruitScore;
    public static float junkScore;

    [HeaderAttribute("Animations")]
    public Sprite[] walking;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody2D;
    private int index = 0;
    //frames per second
    public float animationFPS;
    //controlls speed of walking animation
    private float frameTimer = 0;

    public float lifeTime = 3;
    
    //hearts for ui
    public GameObject heart;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;


    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody2D = GetComponent<Rigidbody2D>();
        vegScore = 0;
        fruitScore = 0;
        junkScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(junkScore == 1)
        {
            Destroy(heart4);
        }
        if (junkScore == 2)
        {
            Destroy(heart3);
        }
        if (junkScore == 3)
        {
            Destroy(heart2);
        }
        if (junkScore == 4)
        {
            Destroy(heart1);
        }

        if (junkScore == 5)
        {
            Destroy(heart);
            isDead = true;
            SceneManager.LoadScene("EndScene");
            Destroy(GetComponent<SpriteRenderer>());
        }
        if (isDead)
        {

            return;
        }

        // move the player left and right, depending on the horizontal input
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //walking animation logic
        Vector2 vel = rBody2D.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        if(vel.x > 0 || vel.x < 0)
        {
            frameTimer -= Time.deltaTime;
            if (frameTimer <= 0.0f)
            {
                frameTimer = 1 / animationFPS;
                index %= walking.Length;
                spriteRenderer.sprite = walking[index];
                index++;
            }
            if(vel.x < -0.01f)
            {
                spriteRenderer.flipX = true;
            } else if (vel.x > 0.01f)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

       //Debug.Log("Collision: " + col.gameObject.name);
       if (col.gameObject.CompareTag("Vegetable"))
        {
            AudioSource.PlayClipAtPoint(goodSound, transform.position);
            Instantiate(star, transform.position, Quaternion.identity);
            vegScore++;
            if (speed <= 7)
            {
                speed = speed + .5f;
            }
           

        }
        if (col.gameObject.CompareTag("Fruit"))
        {
            AudioSource.PlayClipAtPoint(goodSound, transform.position);
            Instantiate(star, transform.position, Quaternion.identity);
            fruitScore++;
            if (speed <= 7)
            {
                speed = speed + .5f;
            }
            
          
        }
        if (col.gameObject.CompareTag("Junk"))
        {
            AudioSource.PlayClipAtPoint(badSound, transform.position);
            Instantiate(x, transform.position, Quaternion.identity);
            junkScore++;
            //decrese speed when player consumes junk food
            if (speed > 1)
            {
                speed = speed - .5f;
            }
           
        }        
           
    }
}
