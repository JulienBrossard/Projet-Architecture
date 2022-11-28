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
        StartCoroutine(DePop());
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    IEnumerator DePop()
    {
        yield return new WaitForSeconds(gunData.bulletLife);
        Pooler.instance.DePop(gameObject.name.Replace("(Clone)", String.Empty), gameObject);
    }
}
