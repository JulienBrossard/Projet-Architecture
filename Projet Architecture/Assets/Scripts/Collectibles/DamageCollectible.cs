using System;
using UnityEngine;

public class DamageCollectible : Collectible, ICollectable
{
    public void Collect()
    {
        PlayerManager.instance.GetGunData().bulletDamage += buff.value;
        Pooler.instance.DePop(gameObject.name.Replace("(Clone)", String.Empty), gameObject);
    }
}
