using UnityEngine;

public class MobManager : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private bool up;
    private bool left;
    private Vector2 randomPos;
    public static MobManager instance;
    
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
    
    public void SpawnMobToRandomPosition(Transform mob)
    {
        int random = Random.Range(0, 4);
        // Up
        if (random == 0)
        {
            randomPos = new Vector2(Random.Range(0, camera.pixelWidth), 0);
            mob.position = new Vector2(camera.ScreenToWorldPoint(randomPos).x, camera.ScreenToWorldPoint(randomPos).y-mob.localScale.y);
            return;
        }
        // Down
        else if (random == 1)
        {
            randomPos = new Vector2(Random.Range(0, camera.pixelWidth), camera.pixelHeight);
            mob.position = new Vector2(camera.ScreenToWorldPoint(randomPos).x, camera.ScreenToWorldPoint(randomPos).y+mob.localScale.y);
            return;
        }
        // Left
        else if (random == 2)
        {
            randomPos = new Vector2(0, Random.Range(0, camera.pixelHeight));
            mob.position = new Vector2(camera.ScreenToWorldPoint(randomPos).x -mob.localScale.x, camera.ScreenToWorldPoint(randomPos).y);
            return;
        }
        // Right
        else if (random == 3)
        {
            randomPos = new Vector2(camera.pixelWidth, Random.Range(0, camera.pixelHeight));
            mob.position = new Vector2(camera.ScreenToWorldPoint(randomPos).x + mob.localScale.x, camera.ScreenToWorldPoint(randomPos).y);
        }
    }
}
