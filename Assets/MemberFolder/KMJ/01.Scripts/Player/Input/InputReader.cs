using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controll;

[CreateAssetMenu(menuName = "InputReader/Player")]
public class InputReader : ScriptableObject, IPlayerActions
{
    private Controll _controls;

    public event Action DashKeyEvent;
    public Vector2 Move { get; private set; }

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controll();
        }
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }


    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            DashKeyEvent?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }
}
