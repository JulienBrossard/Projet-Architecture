using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private PlayerInputs playerInputs; // Player Inputs
    [Header("Player Data")]
    [SerializeField] private PlayerData playerdata; // Player Data
    [Header("Rigidbody")]
    [SerializeField] private Rigidbody2D rb; // Player Rigidbody
    [Header("Current Stats")]
    [SerializeField] public PlayerMovementStats currentStats; // Current Stats
    
    
    void Start()
    {
        currentStats = new PlayerMovementStats(); // Init stats
        playerInputs = InputManager.instance.playerInputs; // Get player inputs
        currentStats.playerData = Instantiate(playerdata);
    }

    void Update()
    {
        Move();
        Dash();
    }

    void Move()
    {
        // Acceleration
        if (playerInputs.PlayerMovement.Movement.ReadValue<Vector2>() != Vector2.zero)
        {
            currentStats.currentSpeed = Mathf.Lerp(currentStats.currentSpeed, currentStats.playerData.speed, currentStats.playerData.acceleration * Time.deltaTime);
            rb.velocity = playerInputs.PlayerMovement.Movement.ReadValue<Vector2>() *  currentStats.currentSpeed;
        }
        
        // Deceleration
        else
        {
            currentStats.currentSpeed = Mathf.Lerp(currentStats.currentSpeed, 0, currentStats.playerData.deceleration * Time.deltaTime);
            rb.velocity = rb.velocity.normalized *  currentStats.currentSpeed;
        }
    }

    void Dash()
    {
        
        // Cooldown
        if (currentStats.currentDashCooldown > 0)
        {
            currentStats.currentDashCooldown -= Time.deltaTime;
        }
        else if(currentStats.currentDashCooldown < 0)
        {
            currentStats.currentDashCooldown = 0;
        }
        
        // Dash
        if (playerInputs.PlayerMovement.Dash.WasPressedThisFrame() && currentStats.currentDashCooldown <= 0)
        {
            rb.AddForce(rb.velocity.normalized * currentStats.playerData.dashForce, ForceMode2D.Impulse);
            currentStats.currentDashCooldown = currentStats.playerData.dashCooldown;
            currentStats.currentSpeed = currentStats.playerData.dashForce;
        }
    }
}

[Serializable]
public class PlayerMovementStats
{
    [Header("Speed")]
    public float currentSpeed;
    [Header("Dash")]
    public float currentDashCooldown;

    [Header("Data")] public PlayerData playerData;
}
