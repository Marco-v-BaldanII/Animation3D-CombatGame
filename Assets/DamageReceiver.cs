using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{

    public float maxHp;
    public bool alive = true;
    private Animator animator;
    Fighter myFighter;
    private void Awake()
    {
        myFighter = GetComponent<Fighter>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") { return; }

        Fighter f = collision.GetComponentInParent<Fighter>();

        if (f == myFighter) { return; }
        if (collision.GetComponent<hurtBox>()) { return; }

        alive = false;
        animator.SetTrigger("defeat");
    }
}
