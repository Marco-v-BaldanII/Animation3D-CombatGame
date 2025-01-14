using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    public Fighter fighter;

    // Start is called before the first frame update
    void Awake()
    {

        playerInput = GetComponent<PlayerInput>();
        var fighters = FindObjectsOfType<Fighter>();
        int controller_index = playerInput.playerIndex;
        fighter = fighters.FirstOrDefault(m => m.GetPlayerIndex() == controller_index);

    }

    public void OnMove(CallbackContext context)
    {
        if( context.started) return;
        print("On moveee");
        fighter.Move(context.ReadValue<Vector2>());
        StartCoroutine(stopPressing( context));
    }

    private IEnumerator stopPressing(CallbackContext context)
    {
        yield return null;
        while (context.performed || context.started)
        {
            print("pressed");
            fighter.Move(context.ReadValue<Vector2>());
            yield return null;
        }
        fighter.Move(context.ReadValue<Vector2>());
    }

    public void OnDodge(CallbackContext context)
    {
        print("move performeddddd");
        if (context.started)
        {
            fighter.PerformAttack("dodge");
        }
    }

    public void OnJump(CallbackContext context)
    {
        if (context.started)
        {
            fighter.Jump();
        }
    }

    public void SPunch(CallbackContext context)
    {
        if (context.started)
        {
            fighter.PerformAttack("s_punch");
        }
    }

    public void WPunch(CallbackContext context)
    {
        if (context.started)
        {
            fighter.PerformAttack("w_punch");
        }
    }

    public void SKick(CallbackContext context)
    {
        if (context.started)
        {
            fighter.PerformAttack("s_kick");
        }
    }

    public void WKick(CallbackContext context)
    {
        if (context.started)
        {
            fighter.PerformAttack("w_kick");
        }
    }

}