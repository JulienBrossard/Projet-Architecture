using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockableLevel : MonoBehaviour
{
    [SerializeField] private ShopItemSO shopItem;
    [SerializeField] private TMP_Text levelName;
    [SerializeField] private TMP_Text levelCost;
    [SerializeField] private Image levelImage;
    [SerializeField] private GameObject unlockButton;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        levelName.text = shopItem.itemName;
        levelCost.text = $"Cost: {shopItem.itemCost}";
        levelImage.sprite = shopItem.itemSprite;

        if (shopItem.name != "Level1")
        {
            levelImage.color = new Color(1.0f, 1.0f, 1.0f, 0.35f);
        }
    }

    public void TryUnlockItem()
    {
        ShopManager.Instance.TryUnlock(shopItem, levelImage, unlockButton);
    }


    public void TryLoadLevel()
    {
        if (shopItem.isUnlocked)
        {
            SceneManager.LoadScene(shopItem.unlockableScene);
        }
    }
}
