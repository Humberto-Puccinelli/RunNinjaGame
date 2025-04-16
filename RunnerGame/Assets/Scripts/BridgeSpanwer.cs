using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpanwer : MonoBehaviour
{
    public GameObject bridge;
    public float bridgeLenght;
    public float spawnRate;
    
    public Transform lastBridge;
    Vector3 newPosition;
    
    bool stop = false;
    int counter = 0;
    
    public GameObject[] obstacles;
    public float obstaclePosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newPosition = lastBridge.transform.position;
        StartCoroutine(SpawnBridge());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBridge()
    {
        while (!stop)
        {
            newPosition.z += bridgeLenght;
            GameObject newBridge = Instantiate(bridge, newPosition, bridge.transform.rotation);
            
            Bridge bridgeScript = newBridge.GetComponent<Bridge>();
            bridgeScript.player = GameObject.FindWithTag("Player").transform;

            yield return new WaitForSeconds(spawnRate);

            if (Random.Range(0, 100) < 50)
            {
                GameObject o = spawnObstacle();
                o.transform.SetParent(newBridge.transform);
            }
        }
    }

    GameObject spawnObstacle()
    {
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
        float obstacleXPos;
       
        /*
        int leftRight = Random.Range(0, 2);
        if (leftRight == 0)
        {
            obstacleXPos = -obstaclePosition;
        }
        else
        {
            obstacleXPos = obstaclePosition;
        }*/
        obstacleXPos = Random.Range(-obstaclePosition, obstaclePosition);
        
        
        Vector3 spawnPos = obstacle.transform.position;
        spawnPos.z = newPosition.z;
        spawnPos.x = obstacleXPos;
        
        GameObject o = Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        return o;
    }
}
