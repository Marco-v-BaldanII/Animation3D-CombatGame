using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
public class Fighter : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float jumpForce = 7f;  
    private bool isGrounded;      
    private Rigidbody2D rb;       
    private Animator animator;

    [SerializeField] int playerIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();

    }

    public void Move(CallbackContext callbackContext)
    {
        float inputX = callbackContext.ReadValue<float>();
        Vector3 move = new Vector3(inputX, 0, 0) * moveSpeed * Time.deltaTime;
        //transform.Translate(move); // Move the player
        rb.velocity = new Vector2(-move.x, rb.velocity.y);
        print(rb.velocity);
    }

    public void Jump()
    {
     
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        
    }

    public void PerformAttack(string atk_name)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Idle"))
        {
            animator.SetTrigger(atk_name);
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

    public int GetPlayerIndex() { return playerIndex; }

}