using System;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Transform player;
    public float destroyDistance = 0.1f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && transform.position.z < player.position.z - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
