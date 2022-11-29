using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    //[SerializeField] private ShopDataSO shopData;
    public static ShopManager Instance;
    private int _playerCoinsAmount = 100; // PLACEHOLDER
    public int PlayerCoinsAmount => _playerCoinsAmount; // PLACEHOLDER

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance); 
        }
        Instance = this;
    }

    public void UpdatePlayerCoins(int unlockedItemCost)
    {
        _playerCoinsAmount -= unlockedItemCost;
    }
}
