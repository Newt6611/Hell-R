using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName="InputReader", menuName="Input/Input Reader")]
public class InputReader : ScriptableObject, M_Input.IPlayerActions
{
    // Player
    public event Action<Vector2> movementEvent;
    public event Action jumpEvent;
    public event Action attackEvent;

    private M_Input input;

    public void Enable() 
    {
        if(input == null)
        {
            input = new M_Input();
            input.Player.SetCallbacks(this);
        }

        EnablePlayer();
    }




    private void OnEnable()
    {
        
    }

    public void EnablePlayer()
    {
        input.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        movementEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
            jumpEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context) 
    {
        if(context.performed)
            attackEvent?.Invoke();
    }
}
