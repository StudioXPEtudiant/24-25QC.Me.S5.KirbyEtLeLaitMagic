using UnityEngine;


public class new_mouvement : MonoBehaviour
{
    public float speed = 10f; // Speed of the character
    public float jumpForce = 5f; // Force applied for jumping
    private Rigidbody2D rb; // Reference to the Rigidbody component
    private bool isGrounded = true; // Check if the character is on the ground
    public float sprint_timer ; 
    float sprint_time = 0f; // Time spent sprinting
    bool sprint = false;
    float cooldown_timer;
    float cooldown_time;
    bool cooldown = false; // Check if cooldown is active 

    void Start()
    {
        // Get the Rigidbody component attached to the character
        rb = GetComponent<Rigidbody2D>();
        if(rb == null)
            Debug.Log("no rb"); 
    }

    void Update()
    {
        // Get input from WASD keys or arrow keys
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Create a movement vector
        Vector2 movement = new Vector2(horizontal, vertical);

        // Apply movement to the character
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Check for jump input (Spacebar) and if the character is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Prevent double jumps
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !cooldown) // Check for sprint input (Shift key) and if cooldown is not active
        {
           
            sprint = true; // Start sprinting
        }
       
        if (sprint)
        {
            speed = 20f; // Increase speed when sprinting
            sprint_time -= Time.deltaTime; // Decrease sprint time
            if (sprint_time <= 0f)
            {
                cooldown = true; // Start cooldown when sprint time runs out
                sprint = false; // Stop sprinting when time runs out
                sprint_time = sprint_timer; // Reset to normal speed 
                speed = 10f; // Reset to normal speed
            }
        }
        if (cooldown)
        {
            cooldown_time -= Time.deltaTime; // Decrease cooldown time
            if (cooldown_time <= 0f)
            {
                cooldown = false; // Stop cooldown when time runs out
                cooldown_time = cooldown_timer; // Reset to normal speed 
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the character is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
    
    
    
