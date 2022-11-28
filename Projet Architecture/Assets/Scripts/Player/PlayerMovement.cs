using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private PlayerInputs playerInputs; // Player Inputs
    [Header("Player Data")]
    public PlayerData playerdata; // Player Data
    [Header("Rigidbody")]
    [SerializeField] private Rigidbody2D rb; // Player Rigidbody
    [Header("Current Stats")]
    [SerializeField] PlayerMovementStats currentStats; // Current Stats
    
    
    void Start()
    {
        currentStats = new PlayerMovementStats(); // Init stats
        playerInputs = InputManager.instance.playerInputs; // Get player inputs
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
            currentStats.currentSpeed = Mathf.Lerp(currentStats.currentSpeed, playerdata.speed, playerdata.acceleration * Time.deltaTime);
            rb.velocity = playerInputs.PlayerMovement.Movement.ReadValue<Vector2>() *  currentStats.currentSpeed;
        }
        
        // Deceleration
        else
        {
            currentStats.currentSpeed = Mathf.Lerp(currentStats.currentSpeed, 0, playerdata.deceleration * Time.deltaTime);
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
            rb.AddForce(Vector3.right * playerdata.dashForce, ForceMode2D.Impulse);
            currentStats.currentDashCooldown = playerdata.dashCooldown;
            currentStats.currentSpeed = playerdata.dashForce;
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
}
