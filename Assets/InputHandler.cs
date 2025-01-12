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

    // Update is called once per frame
    void Update()
    {

    }

    public void function()
    {

    }

    public void OnMove(CallbackContext context)
    {
        fighter.Move(context);
    }

}