using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody2D enemyBody;
    private Transform player;

    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        if (enemyBody == null)
        {
            Debug.LogError("EnemyChase requires a Rigidbody2D.", this);
            enabled = false;
        }
    }

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
        {
            Debug.LogError("EnemyChase could not find a GameObject tagged Player.", this);
            enabled = false;
            return;
        }

        player = playerObject.transform;
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        Vector2 direction = ((Vector2)player.position - enemyBody.position).normalized;
        enemyBody.linearVelocity = direction * speed;
    }
}
