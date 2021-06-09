using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] food;
    private float lastSpawnTime = 0;
    //how many food spawn per second
    public float spawnRate = 1;
    public float spawnWidth = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawning food
        if(lastSpawnTime +1 / spawnRate < Time.time)
        {
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(Random.Range(-spawnWidth, spawnWidth), 0, 0);

            //creating gameObject to spawn
            int index = Random.Range(0, food.Length);
            Instantiate(food[index], spawnPosition, Quaternion.identity);

        }
    }

    //visualizing foodSpawn window
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position - new Vector3(spawnWidth, 0, 0), transform.position + new Vector3(spawnWidth, 0, 0));
        Gizmos.DrawLine(transform.position - new Vector3(spawnWidth, 1, 0), transform.position - new Vector3(spawnWidth, -1, 0));
        Gizmos.DrawLine(transform.position + new Vector3(spawnWidth, 1, 0), transform.position + new Vector3(spawnWidth, -1, 0));
    }
}
