using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class UnlockableLevel : MonoBehaviour
{
    [SerializeField] private ShopItemSO shopItem;
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private TMP_Text levelCost;
    [SerializeField] private Image levelImage;

    private void Start()
    {
        Init(); 
    }

    private void Init()
    {
        levelName.text = shopItem.name;
        levelCost.text = $"Cost: {shopItem.itemCost}";
        levelImage.sprite = shopItem.itemSprite;
        levelImage.color = new Color(1.0f, 1.0f, 1.0f, 0.35f);
    }

    public void TryUnlockItem()
    {
        if (ShopManager.Instance.PlayerCoinsAmount >= shopItem.itemCost)
        {
            OnUnlock();

            // AudiovisualFeedback.DoFeedback(); 
        }
    }

    public void TryLoadLevel()
    {
        if (shopItem.isUnlocked)
        {
            // load proper scene scene
        }
    }


    // turn into an interface for various types of shop items
    private void OnUnlock()
    {
        shopItem.isUnlocked = true;
        ShopManager.Instance.UpdatePlayerCoins(shopItem.itemCost);
        levelImage.color = Color.white;

        // AudiovisualFeedback.DoFeedback();

        // new level is now available
        // update shop data & player data
    }
}
