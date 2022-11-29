using System;
using UnityEngine;

public class SpeedCollectible : Collectible, ICollectable
{
    public void Collect()
    {
        PlayerManager.instance.GetPlayerData().speed += buff.value;
        Pooler.instance.DePop(gameObject.name.Replace("(Clone)", String.Empty), gameObject);
    }
}
