using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void Finish(bool result)
    {
        UIManager.instance.result.visible = true;
        if (result)
        {
            UIManager.instance.result.text = "You win";
        }
        else
        {
            UIManager.instance.result.text = "You loose";
        }
        PauseManager.instance.End();
    }
}
