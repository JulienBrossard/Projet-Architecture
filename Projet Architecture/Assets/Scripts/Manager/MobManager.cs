using Pathfinding;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private bool up;
    private bool left;
    private Vector2 randomPos;
    public static MobManager instance;
    private int mobCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMob()
    {
        mobCount++;
    }

    public void RemoveMob()
    {
        mobCount--;
    }

    public void SpawnMobToRandomPosition(Transform mob)
    {
        Debug.Log("spawning");
        int random = Random.Range(0, 4);
        // Up
        if (random == 0)
        {
            randomPos = new Vector2(Random.Range(0, camera.pixelWidth), 0);
            mob.position = new Vector2(camera.ScreenToWorldPoint(randomPos).x, camera.ScreenToWorldPoint(randomPos).y - mob.localScale.y);
            return;
        }
        // Down
        else if (random == 1)
        {
            randomPos = new Vector2(Random.Range(0, camera.pixelWidth), camera.pixelHeight);
            mob.position = new Vector2(camera.ScreenToWorldPoint(randomPos).x, camera.ScreenToWorldPoint(randomPos).y + mob.localScale.y);
            return;
        }
        // Left
        else if (random == 2)
        {
            randomPos = new Vector2(0, Random.Range(0, camera.pixelHeight));
            mob.position = new Vector2(camera.ScreenToWorldPoint(randomPos).x - mob.localScale.x, camera.ScreenToWorldPoint(randomPos).y);
            return;
        }
        // Right
        else if (random == 3)
        {
            randomPos = new Vector2(camera.pixelWidth, Random.Range(0, camera.pixelHeight));
            mob.position = new Vector2(camera.ScreenToWorldPoint(randomPos).x + mob.localScale.x, camera.ScreenToWorldPoint(randomPos).y);
        }
    }

    public void SpawnMob(GameObject mob, Vector3 position)
    {
        mob.transform.position = position;
        mob.GetComponent<AIDestinationSetter>().target = LevelManager.instance.player;
    }
}
