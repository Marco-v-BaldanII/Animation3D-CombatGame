using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{

    public float maxHp;
    public bool alive = true;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        alive = false;
    }
}
