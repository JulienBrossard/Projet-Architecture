using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Data")]
    [SerializeField] GunData gunData;
    [Header("Current Stats")]
    [SerializeField] GunStats gunCurrentStats;

    private GameObject currentBullet;
    private Bullet bulletScript;
    private bool isReload = false;

    private void Start()
    {
        gunCurrentStats.currentAmmo = gunData.maxAmmo;
    }

    private void Update()
    {
        UpdateShootCooldown();
    }

    public void UpdateShootCooldown()
    {
        if (gunCurrentStats.shootCooldown > 0)
        {
            gunCurrentStats.shootCooldown -= Time.deltaTime;
        }
        else if (gunCurrentStats.shootCooldown < 0)
        {
            gunCurrentStats.shootCooldown = 0;
        }
    }

    public void Shoot(Vector2 dir)
    {
        if (gunCurrentStats.shootCooldown <= 0 && !isReload)
        {
            currentBullet = Pooler.instance.Pop(gunData.bulletName);
            currentBullet.transform.position = transform.position;
            bulletScript = currentBullet.GetComponent<Bullet>();
            bulletScript.UpdateData(gunData);
            bulletScript.AddForce(gunData.bulletForce * dir);
            gunCurrentStats.shootCooldown = gunData.fireRate;
            gunCurrentStats.currentAmmo--;
            if (gunCurrentStats.currentAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
        }
    }
    
    public IEnumerator Reload()
    {
        if (!isReload)
        {
            isReload = true;
            yield return  new WaitForSeconds(gunData.reloadTime);
            gunCurrentStats.currentAmmo = gunData.maxAmmo;
            isReload = false;
        }
        else
        {
            yield return null;
        }
    }
}

[Serializable]
public class GunStats
{
    public float shootCooldown;
    public int currentAmmo;
}
