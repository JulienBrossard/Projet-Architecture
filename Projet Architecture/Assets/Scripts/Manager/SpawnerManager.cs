using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    int spawnerCount = 0;
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
        spawnerCount++;
        UIManager.instance.spawnerCount.text = spawnerCount.ToString();
    }

    public void RemoveSpawner()
    {
        spawnerCount--;
        UIManager.instance.spawnerCount.text = spawnerCount.ToString();
        if (spawnerCount <= 0)
        {
            GameManager.Finish(true);
        }
    }
}
