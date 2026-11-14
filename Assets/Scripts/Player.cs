using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;

    private void Start()
    {
        Debug.Log("Player has started.");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
            Debug.Log("Player is moving up.");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            Debug.Log("Player is moving left.");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
            Debug.Log("Player is moving right.");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
            Debug.Log("Player is moving down.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
            Debug.Log("Player is moving up.");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
            Debug.Log("Player is moving left.");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            Debug.Log("Player is moving right.");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
            Debug.Log("Player is moving down.");
        }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with an enemy.");
        }
        else
        {
            Debug.Log("Player has collided with an unknown object.");
        }

        Debug.Log("Player has collided with " + collision.gameObject.name);
    }
}
