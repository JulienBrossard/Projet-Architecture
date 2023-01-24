using System;
using UnityEngine;

public enum FireballType { NONE, Small = 5, Medium = 10, Big = 20 }

[RequireComponent(typeof(CircleCollider2D))]
public class Fireball : MonoBehaviour
{
    [SerializeField] private FireballType type;
    [SerializeField, Range(1, 10)] private float speed = 1;
    [SerializeField, Range(1, 5)] private float lifeTime = 2;

    Action<int> OnDamageEntity;

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime * (transform.up * -1), Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // REFACTOR: Use an IDamageable interface
        ApplyDamage(); 
    }

    public void Init(Vector2 dir)
    {
        Destroy(gameObject, lifeTime);

        transform.rotation = Quaternion.FromToRotation(Vector3.down, dir);
    }

    private void ApplyDamage()
    {
        // OnDamageEntity((int)type);
        Destroy(gameObject);
    }

}
