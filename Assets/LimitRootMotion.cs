using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitRootMotion : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnAnimatorMove()
    {
        if (animator.applyRootMotion)
        {
            // Get the root motion delta from the animation
            Vector3 deltaPosition = animator.deltaPosition;

            // Only apply Z and Y movement, ignore X
            deltaPosition.z = 0;

            // Apply the modified root motion to the transform
            transform.Translate(deltaPosition, Space.World);
        }
    }
}
