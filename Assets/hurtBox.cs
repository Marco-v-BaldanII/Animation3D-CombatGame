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
        var s = collision.GetComponentInParent<DamageReceiver>();
        if (s == null || damageReceiver == null || s == damageReceiver  || collision.enabled == false) { return; }

        damageReceiver?.OnTriggerEnter2D(collision);
    }

}
