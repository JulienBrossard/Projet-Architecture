using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletLauncher : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    private const int maxPoolSize = 2;

    private void Awake()
    {
        IObjectPool<Bullet> pooler = new ObjectPool<Bullet>(OnCreatePoolItem, ActionOnGet, ActionOnRelease,
            ActionOnDestroy, true, 10, maxPoolSize);
    }

    private void ActionOnDestroy(Bullet obj)
    {
        
    }

    private void ActionOnRelease(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void ActionOnGet(Bullet obj)
    {
        obj.gameObject.SetActive(true);
    }

    private Bullet OnCreatePoolItem()
    {
        var bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, this.transform);
        return bullet;
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, this.transform);
        }
    }
}
