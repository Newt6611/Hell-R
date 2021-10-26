using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName="InputReader", menuName="Input/Input Reader")]
public class InputReader : ScriptableObject, M_Input.IPlayerActions, M_Input.IUIActions
{
    // Player
    public event Action<Vector2> movementEvent;
    public event Action jumpEvent;
    public event Action attackEvent;
    public event Action defendEvent;
    public event Action defendKeyUpEvent;
    public event Action intoDoorEvent;
    public event Action getItemEvent;
    public event Action useItemEvent;

    // BackPack Item ( Keybaord )
    public event Action itemOneEvent;
    public event Action itemTwoEvent;
    public event Action itemThreeEvent;
    public event Action itemFourEvent;
    public event Action itemFiveEvent;

    // ui
    public event Action ui_OnPressed;
    public event Action ui_OnHighlight;
    public event Action ui_OnSubmit;
    public event Action ui_OnRight;
    public event Action ui_OnLeft;
    public event Action ui_OnExit;

    public event Action controlChangeEvent;

    private M_Input input;

    public void Enable() 
    {
        if(input == null)
        {
            input = new M_Input();
            input.Player.SetCallbacks(this);
            input.UI.SetCallbacks(this);
        }

        EnablePlayer();
    }



    public void EnablePlayer()
    {
        input.UI.Disable();
        input.Player.Enable();
    }

    public void DisablePlayer()
    {
        input.Player.Disable();
        input.UI.Enable();
    }



    public void OnControllerChange()
    {
        controlChangeEvent?.Invoke();
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

    public void OnDefend(InputAction.CallbackContext context) 
    {
        if(context.performed)
            defendEvent?.Invoke();
    
        if(context.canceled)
            defendKeyUpEvent?.Invoke();
    }

    public void OnIntoDoor(InputAction.CallbackContext context)
    {
        if(context.performed)
            intoDoorEvent?.Invoke();
    }

    public void OnItemOne(InputAction.CallbackContext context)
    {
        if(context.performed)
            itemOneEvent?.Invoke();
    }

    public void OnItemTwo(InputAction.CallbackContext context)
    {
        if(context.performed)
            itemTwoEvent?.Invoke();
    }

    public void OnItemThree(InputAction.CallbackContext context)
    {
        if(context.performed)
            itemThreeEvent?.Invoke();
    }

    public void OnItemFour(InputAction.CallbackContext context)
    {
        if(context.performed)
            itemFourEvent?.Invoke();
    }

    public void OnItemFive(InputAction.CallbackContext context)
    {
        if(context.performed)
            itemFiveEvent?.Invoke();
    }

    public void OnGetItem(InputAction.CallbackContext context)
    {
        if(context.performed)
            getItemEvent?.Invoke();
    }

    public void OnUseItem(InputAction.CallbackContext context)
    {
        if(context.performed)
            useItemEvent?.Invoke();
    }

    /////////////////////////////////////////////////////////////////
    // UI
    /////////////////////////////////////////////////////////////////
    public void OnPress(InputAction.CallbackContext context)
    {
        if(context.performed)
            ui_OnPressed?.Invoke();
    }

    public void OnHighLight(InputAction.CallbackContext context)
    {
        if(context.performed)
            ui_OnHighlight?.Invoke();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if(context.performed)
            ui_OnSubmit?.Invoke();
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if(context.performed)
            ui_OnRight?.Invoke();
    }

    public void OnLeft(InputAction.CallbackContext context) 
    {
        if(context.performed)
            ui_OnLeft?.Invoke();
    }

    public void OnExit(InputAction.CallbackContext context)
    {
        if(context.performed)
            ui_OnExit?.Invoke();
    }

}
