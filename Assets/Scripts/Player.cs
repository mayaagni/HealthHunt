using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private float vegScore = 0;
    private float fruitScore = 0;
    private float junkScore = 0;

    [HeaderAttribute("Animations")]
    public Sprite[] walking;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody2D;
    private int index = 0;
    //frames per second
    public float animationFPS;
    //controlls speed of walking animation
    private float frameTimer = 0;
    
  

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

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
       if (col.gameObject.CompareTag("Vegetable"))
        {
            if(speed <= 5)
            {
                speed = speed + .3f;
            }
            Instantiate(star, transform.position, Quaternion.identity);
            // load the active scene again, to restard the game. The GameManager will handle this for us. We use a slight delay to see the explosion.
            vegScore++;
        }
        if (col.gameObject.CompareTag("Fruit"))
        {
            if(speed <= 5)
            {
                speed = speed + .3f;
            }
            Instantiate(star, transform.position, Quaternion.identity);
            // load the active scene again, to restard the game. The GameManager will handle this for us. We use a slight delay to see the explosion.
            fruitScore++;
        }
        if (col.gameObject.CompareTag("Junk"))
        {
            //decrese speed when player consumes junk food
            speed = speed - .3f;
            Instantiate(x, transform.position, Quaternion.identity);
            // load the active scene again, to restard the game. The GameManager will handle this for us. We use a slight delay to see the explosion.
            junkScore++;
            if(junkScore >=4)
            {
                isDead = true;
                Destroy(GetComponent<SpriteRenderer>());
                
            }
        }
    }
}
