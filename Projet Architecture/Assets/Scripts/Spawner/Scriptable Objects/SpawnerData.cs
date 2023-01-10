using UnityEngine;

[CreateAssetMenu(fileName = "Spawner Data", menuName = "Scriptable Objects/SpawnerData")]
public class SpawnerData : ScriptableObject
{
    public Mob mob;
    public float spawnRadius;
    public float minSpawnSpeed;
    public float maxSpawnSpeed;
    public int minNpcSpawn;
    public int maxNpcSpawn;
}
