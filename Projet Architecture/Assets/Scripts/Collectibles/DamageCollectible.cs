using System;
using UnityEngine;

public class DamageCollectible : Collectible, ICollectable
{
    public void Collect()
    {
        PlayerManager.instance.GetGunData().bulletDamage += buff.value;
        if (PlayerManager.instance.GetGunData().bulletDamage > PlayerManager.instance.GetGunData().maxDamage)
        {
            PlayerManager.instance.GetGunData().bulletDamage = PlayerManager.instance.GetGunData().maxDamage;
        }
        UIManager.instance.damageBonus.text = PlayerManager.instance.GetGunData().bulletDamage.ToString();
        Pooler.instance.DePop(gameObject.name.Replace("(Clone)", String.Empty), gameObject);
    }
}
