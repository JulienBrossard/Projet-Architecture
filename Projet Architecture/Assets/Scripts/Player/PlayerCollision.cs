using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Dictionary<GameObject, IEnumerator> damageDictionary = new Dictionary<GameObject, IEnumerator>();

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            IEnumerator enumerator =
                PlayerManager.instance.TakeMultipleDamage(col.gameObject.GetComponent<Mob>().entityData.damage, 1);
            damageDictionary.Add(col.gameObject, enumerator);
            StartCoroutine(enumerator);
        }
        
        else if (col.collider.GetComponent<ICollectable>() != null)
        {
            col.collider.GetComponent<ICollectable>().Collect();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy") && damageDictionary.ContainsKey(other.gameObject))
        {
            StopCoroutine(damageDictionary[other.gameObject]);
            damageDictionary.Remove(other.gameObject);
        }
    }
}
