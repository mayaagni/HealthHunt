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

    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        // move the player left and right, depending on the horizontal input
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.CompareTag("Vegetable"))
        {
            Instantiate(star, transform.position, Quaternion.identity);
            // load the active scene again, to restard the game. The GameManager will handle this for us. We use a slight delay to see the explosion.
            vegScore++;
        }
        if (col.gameObject.CompareTag("Fruit"))
        {
            Instantiate(star, transform.position, Quaternion.identity);
            // load the active scene again, to restard the game. The GameManager will handle this for us. We use a slight delay to see the explosion.
            fruitScore++;
        }
        if (col.gameObject.CompareTag("Junk"))
        {
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
