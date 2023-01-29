using System;
using UnityEngine;

public enum FireballType { NONE, Small = 1, Medium = 5, Big = 10 }

[RequireComponent(typeof(CircleCollider2D))]
public class Fireball : MonoBehaviour
{
    [SerializeField] private FireballType type;
    [SerializeField, Range(1, 10)] private float speed = 1;
    [SerializeField, Range(1, 5)] private float lifeTime = 2;

    public void Init(Vector2 dir)
    {
        Destroy(gameObject, lifeTime);

        transform.rotation = Quaternion.FromToRotation(Vector3.down, dir);
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime * (transform.up * -1), Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        PlayerManager.instance.TakeDamage((float)type, 0.4f);
        Destroy(gameObject);
    }
}
