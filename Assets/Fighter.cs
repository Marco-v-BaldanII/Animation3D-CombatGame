using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
public class Fighter : MonoBehaviour
{
    public float moveSpeed = 5f;   // Speed of movement
    public float jumpForce = 7f;   // Force applied when jumping
    private bool isGrounded;       // Check if player is on the ground
    private Rigidbody2D rb;        // Rigidbody2D component
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        Jump();
    }

    public void Move(CallbackContext callbackContext)
    {
        float inputX = callbackContext.ReadValue<float>();
        Vector3 move = new Vector3(inputX, 0, 0) * moveSpeed * Time.deltaTime;
        //transform.Translate(move); // Move the player
        rb.velocity = new Vector2(-move.x, rb.velocity.y);
        print(rb.velocity);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Check for ground collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}