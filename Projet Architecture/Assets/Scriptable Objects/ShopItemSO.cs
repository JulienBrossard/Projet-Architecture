using UnityEngine;


[CreateAssetMenu(fileName = "Shop Item", menuName = "Shop/Item")]
public class ShopItemSO : ScriptableObject
{
    public string itemName;
    public int itemCost;
    public Sprite itemSprite;
    public bool isUnlocked;   
}
