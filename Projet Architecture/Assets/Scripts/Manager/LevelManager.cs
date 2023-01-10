using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform player;
    public static LevelManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }
}
