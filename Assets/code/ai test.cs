using UnityEngine;

public class aitest : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float changeDirectionTime = 2f;

    private Vector2 moveDirection;
    private float timer;

    void Start()
    {
        PickNewDirection();
    }

    void Update()
    {
        // Move the AI
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Change direction after a set time
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            PickNewDirection();
            timer = 0f;
        }
    }

    void PickNewDirection()
    {
        // Pick a random direction (left or right)
        float direction = Random.Range(0, 2) == 0 ? -1f : 1f;
        moveDirection = new Vector2(direction, 0f); // Only move along the x-axis
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object has a collider (circle or square)
        if (collision.collider != null)
        {
            Debug.Log("Collided with: " + collision.collider.name);

            // Reverse direction upon collision
            moveDirection = new Vector2(-moveDirection.x, moveDirection.y);
        }
    }
}