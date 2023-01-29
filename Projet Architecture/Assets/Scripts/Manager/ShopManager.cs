using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private ShopDataSO shopData;
    [SerializeField] private TMP_Text tmp;

    public static ShopManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    private void Start()
    {
        tmp.text = $" : {shopData.Credits}";
    }

    public void UpdatePlayerCredits(int unlockedItemCost)
    {
        shopData.Credits -= unlockedItemCost;
    }

    public void TryUnlock(ShopItemSO item, Image levelImage, GameObject btn)
    {
        if (item.itemCost <= shopData.Credits)
        {
            item.isUnlocked = true;
            UpdatePlayerCredits(item.itemCost);
            levelImage.color = Color.white;
            btn.SetActive(false);
        }
    }
}
