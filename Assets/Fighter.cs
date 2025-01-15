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

    private VoiceLines voiceLines;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        voiceLines = GetComponent<VoiceLines>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Move();
        // animator.SetFloat("input_x", Mathf.Abs( rb.velocity.x ));

        animator.ResetTrigger("w_kick");
        animator.ResetTrigger("s_kick");
        animator.ResetTrigger("s_punch");
        animator.ResetTrigger("w_punch");
    }

    public void Move(Vector2 input)
    {
        float inputX = input.x;

       

        Vector3 move = new Vector3(inputX, 0, 0) * moveSpeed * Time.deltaTime;
        if (playerIndex == 1) { move.x *= -1; }
        //transform.Translate(move); // Move the player
        //rb.velocity = new Vector2(-move.x, rb.velocity.y);
        //if (move.x < 0)
        //{
        //    animator.SetTrigger("inputX");
        //}
        //else if (move.x > 0)
        //{
        //    //animator.SetTrigger("a");

        //}
        animator.SetFloat("input_x", move.x);
    }

    public void Jump()
    {

        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //isGrounded = false;
        animator.SetTrigger("jump");
    }

    public void PerformAttack(string atk_name)
    {

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Idle") || stateInfo.IsName("walk") || stateInfo.IsName("walk_0"))
        {
            print("Fighter is performing " + atk_name);

            animator.SetTrigger(atk_name);
            voiceLines?.PlayRandomClip();
            if (atk_name == "s_punch")
            {
                animator.ResetTrigger("s_kick");
                animator.ResetTrigger("w_kick");
                animator.ResetTrigger("w_punch");
            }
            else if (atk_name == "s_kick")
            {
                animator.ResetTrigger("s_punch");
                animator.ResetTrigger("w_kick");
                animator.ResetTrigger("w_punch");

            }
            else if (atk_name == "w_kick")
            {
                animator.ResetTrigger("s_punch");
                animator.ResetTrigger("s_kick");
                animator.ResetTrigger("w_punch");

            }
            else if (atk_name == "w_punch")
            {
                animator.ResetTrigger("w_kick");
                animator.ResetTrigger("s_kick");
                animator.ResetTrigger("s_punch");

            }
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