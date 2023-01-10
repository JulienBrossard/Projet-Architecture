using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    #if UNITY_EDITOR
    private void OnSceneGUI()
    {
        EnemySpawner spawner = (EnemySpawner)target;
        Handles.color = Color.red;
        Handles.DrawWireDisc(spawner.transform.position, Vector3.forward, spawner.spawnerData.spawnRadius);
    }
    #endif
}
