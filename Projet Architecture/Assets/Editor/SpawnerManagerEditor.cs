using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SpawnerManager))]
public class SpawnerManagerEditor : Editor
{
    private void OnSceneGUI()
    {
        SpawnerManager spawnerManager = (SpawnerManager)target;
        foreach (var spawner in spawnerManager.spawners)
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(spawner.transform.position, Vector3.forward, spawner.spawnerData.spawnRadius);
        }
    }
}
