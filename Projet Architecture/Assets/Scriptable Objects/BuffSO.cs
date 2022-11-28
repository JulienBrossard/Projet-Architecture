using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    Damage,
    FireRate,
    Speed
}

[CreateAssetMenu(order = 1,fileName = "BuffSO", menuName = "Buff SO/Buff")]
public class BuffSO : ScriptableObject
{
    public BuffType buffType;
    public float value;
}
