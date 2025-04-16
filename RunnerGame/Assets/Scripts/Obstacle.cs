using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool hasScored = false;
    private bool hasCollided = false;
    private Transform player;

    public float checkDistance = 1f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null && !hasScored)
        {
            // Se o jogador passou do obstáculo no eixo Z
            if (player.position.z > transform.position.z + checkDistance && !hasCollided)
            {
                GameManager gm = FindObjectOfType<GameManager>();
                if (gm != null)
                {
                    gm.AddScore(1);
                }
                hasScored = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasCollided = true; // Ele bateu, então não ganha ponto
        }
    }
}