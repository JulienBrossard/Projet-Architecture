using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    
    public PlayerInputs playerInputs;

    public MenuInputs menuInputs;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        playerInputs = new PlayerInputs();
        playerInputs.Enable();

        menuInputs = new MenuInputs();
        menuInputs.Enable();
    }
}
