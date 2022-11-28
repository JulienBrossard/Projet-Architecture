using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Speed")]
    public float speed;
    public float acceleration;
    public float deceleration;
    [Header("Dash")]
    public float dashForce;
    public float dashCooldown;
    [Header("Fight")]
    public float health;
}
