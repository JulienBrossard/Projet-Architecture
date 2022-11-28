using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    
    public PlayerInputs playerInputs;

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
    }
}
