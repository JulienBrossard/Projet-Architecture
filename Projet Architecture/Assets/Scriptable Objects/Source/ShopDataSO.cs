using UnityEngine;

[CreateAssetMenu(fileName = "Shop Data", menuName = "Shop/Data")]
public class ShopDataSO : ScriptableObject
{
    public int Credits { get; set; }

    [Header("-- DEBUG --")]
    public int debugStartingCredits = 0;

    void OnValidate()
    {
        Credits = debugStartingCredits;
    }
}
