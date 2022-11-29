using UnityEngine;

[CreateAssetMenu(fileName = "Mob Data", menuName = "Scriptable Objects/Mob Data")]
public class MobData : ScriptableObject
{
    [Range(0,1)]
    public float collectibleSpawnChance;
    public GameObject[] collectiblesPrefab;
}
