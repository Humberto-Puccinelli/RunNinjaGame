using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float limitX;
    public float moveRate = 1.0f;
    
    Vector3 mousePosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            GetComponent<Animator>().Play("Idle");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        touchInput();
    }

    void Run()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void touchInput()
    {
        Vector3 inputPosition = Vector3.zero;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            inputPosition = touch.position;
        }
        else if (Input.GetMouseButton(0))
        {
            inputPosition = Input.mousePosition;
        }
        else
        {
            return;
        }
        
        inputPosition.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(inputPosition);
        
        Vector3 newPosition = transform.position;
        newPosition.x = worldPosition.x;

        transform.position = Vector3.Lerp(transform.position, newPosition, moveRate);
        
        float clampedX = Mathf.Clamp(transform.position.x, -limitX, limitX);
        Vector3 limitedPosition = transform.position;
        limitedPosition.x = clampedX;
        transform.position = limitedPosition;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
