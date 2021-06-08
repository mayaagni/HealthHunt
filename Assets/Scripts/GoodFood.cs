using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodFood : MonoBehaviour
{

    Vector2 direction = new Vector2();
    public float speed = 1.5f;
    public float rotationSpeed = 5;

    //how long food lives before it is automatically destroyed
    public float lifeTime = 10;
  
    void Start()
    {
        direction = new Vector2(0, -1);
        //normalize direction so travel speed it not impacted
        direction.Normalize();
        
    }

    //fruit moves downward
    void Update()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward);

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
