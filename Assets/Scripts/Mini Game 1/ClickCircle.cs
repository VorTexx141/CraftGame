using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class ClickCircle : MonoBehaviour
{
    #region Veriables
    [SerializeField] private Collider2D col;
    [SerializeField] private Animator animator;

    private bool IsGoodTime = false;
    private bool IsPerfectTime = false;

    PlayerInput input;
    #endregion

    #region SUBS
    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }

    private void Awake()
    {
        input = new PlayerInput();
        
        input.Player.MouseClick.performed += MouseClick_performed;
    }
    #endregion

    private void MouseClick_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 mousePosition = input.Player.MousePosition.ReadValue<Vector2>();

        if (col.OverlapPoint(mousePosition))
        {
            if (IsGoodTime)
            {
                UnitManager.instance.invokeSpown();
                Debug.Log("Good!");
                Destroy(col.gameObject);
            }
            else if (IsPerfectTime)
            {
                UnitManager.instance.invokeSpown();
                Debug.Log("Perfect!");
                Destroy(col.gameObject);
            }
            else 
            {
                UnitManager.instance.invokeSpown();
                Debug.Log("NOT GOOD!!");
                Destroy(col.gameObject);
            }
        }
    }

    #region Animation Events
    public void GoodTime()
    {
        IsGoodTime = true;
    }

    public void PerfectTime()
    {
        IsGoodTime = false;
        IsPerfectTime = true;
    }

    public void End()
    {
        UnitManager.instance.invokeSpown();
        IsPerfectTime = false;
        Destroy(col.gameObject);
    }
    #endregion
}
