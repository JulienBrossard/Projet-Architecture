using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private GunData gunData;

    public void UpdateData(GunData gunData)
    {
        this.gunData = gunData;
        StartCoroutine(Kill());
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(gunData.bulletLife);
        DePop();
    }

    void DePop()
    {
        Pooler.instance.DePop(gameObject.name.Replace("(Clone)", String.Empty), gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<Entity>().TakeDamage(gunData.bulletDamage, col.gameObject.name);
            }
            DePop();
        }
    }
}
