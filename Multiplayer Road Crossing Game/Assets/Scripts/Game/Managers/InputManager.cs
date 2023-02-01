using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    private PlayerController playerController;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
        playerController = new PlayerController();
    }

    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    public Vector2 GetPlayerInputs()
    {
        return playerController.CharController.Movement.ReadValue<Vector2>();
    }

    public bool EscapeButtonInfo()
    {
        if (playerController.CharController.EscapeButton.triggered)
        {
            return true;
        }
        else return false;
    }
}
