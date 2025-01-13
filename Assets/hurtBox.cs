using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtBox : MonoBehaviour
{

    public DamageReceiver damageReceiver;

    private void Awake()
    {
        damageReceiver = GetComponentInParent<DamageReceiver>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        damageReceiver.OnTriggerEnter2D(collision);
    }

}
