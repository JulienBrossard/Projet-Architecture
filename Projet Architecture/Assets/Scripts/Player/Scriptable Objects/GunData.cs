using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun Data", menuName = "Scriptable Objects/GunData")]
public class GunData : ScriptableObject
{
    [Header("Name")]
    public String bulletName;
    [Header("Shoot")]
    public float fireRate = 0.5f;
    public float minFireRate;
    public float bulletForce = 1000f;
    public float bulletLife = 2f;
    public float bulletDamage = 10f;
    public float maxDamage;
    [Header("Reload")]
    public float reloadTime = 1f;
    public int maxAmmo = 15;
}
