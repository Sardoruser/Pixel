using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;

    private bool hasLost;

    private void Start()
    {
        Debug.Log("Player has started.");
    }

    private void Update()
    {
        if (hasLost)
        {
            return;
        }

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
        if (hasLost)
        {
            return;
        }

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
        else if (collision.gameObject.CompareTag("Keys"))
        {
            Debug.Log("Player has collected a key.");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            hasLost = true;
            Debug.Log("Game Over! The player collided with an enemy.");

            Rigidbody2D playerBody = GetComponent<Rigidbody2D>();
            if (playerBody != null)
            {
                playerBody.linearVelocity = Vector2.zero;
            }

            Invoke(nameof(RestartLevel), 1.5f);
        }
        else
        {
            Debug.Log("Player has collided with an unknown object.");
        }

        Debug.Log("Player has collided with " + collision.gameObject.name);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
