using System;
using UnityEngine;

public class SpeedCollectible : Collectible, ICollectable
{
    public void Collect()
    {
        PlayerManager.instance.GetPlayerData().speed += buff.value;
        if (PlayerManager.instance.GetPlayerData().speed > (PlayerManager.instance.GetPlayerData().maxSpeed))
        {
            PlayerManager.instance.GetPlayerData().speed = PlayerManager.instance.GetPlayerData().maxSpeed;
        }
        UIManager.instance.speedBonus.text = PlayerManager.instance.GetPlayerData().speed.ToString();
        Pooler.instance.DePop(gameObject.name.Replace("(Clone)", String.Empty), gameObject);
    }
}
