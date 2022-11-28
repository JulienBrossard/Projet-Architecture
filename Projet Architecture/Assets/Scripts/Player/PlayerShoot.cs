using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Pointer")] 
    [SerializeField] 
    private PointerData pointer;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform player;
    private Vector2 playerScreenPos;
    private Vector2 direction;
    [Header("Gun")]
    [SerializeField] private Gun gun;
    private PlayerInputs playerInputs;

    private void Start()
    {
        playerInputs = InputManager.instance.playerInputs;
    }

    private void Update()
    {
        UpdatePointerPos();
        Shoot();
        Reload();
    }

    void UpdatePointerPos()
    {
        playerScreenPos = camera.WorldToScreenPoint(player.position);
        direction = new Vector2(Input.mousePosition.x, (Input.mousePosition.y)) - playerScreenPos;
        pointer.pointerObject.position = direction + playerScreenPos;
        if (Vector2.Distance(pointer.pointerObject.position, playerScreenPos) > pointer.maxRadius)
        {
            pointer.pointerObject.position = direction.normalized * pointer.maxRadius + playerScreenPos;
        }
    }

    void Shoot()
    {
        if (playerInputs.PlayerShoot.Shoot.IsPressed())
        {  
            gun.Shoot(direction.normalized);
        }
    }

    void Reload()
    {
        if (playerInputs.PlayerShoot.Reload.WasPressedThisFrame())
        {
            StartCoroutine(gun.Reload());
        }
    }
}

[Serializable]
public class PointerData
{
    public RectTransform pointerObject;
    public float maxRadius;
}
