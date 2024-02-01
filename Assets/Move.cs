using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float acceleration = 2f;
    private float currentSpeed = 0f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private bool jumpKeyHeld = false;
    private Rigidbody2D rb; // Only declare rb once

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float targetSpeed = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetSpeed = maxSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetSpeed = -maxSpeed;
        }

        // Interpolate the current speed towards the target speed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        // Apply the current speed to the Rigidbody
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumpKeyHeld = true;
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
        }
        else
        {
            jumpKeyHeld = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9f)
                {
                    isJumping = false;
                }
            
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
           isJumping = true;
        }
    }
}