using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    int spawnCount = 0;
    public EnemySpawner[] spawners;
    
    public static SpawnerManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }
    
    public void AddSpawner()
    {
        spawnCount++;
    }

    public void RemoveSpawner()
    {
        spawnCount--;
    }
}
