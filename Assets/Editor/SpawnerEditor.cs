using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    private void OnDisable()
    {
        // Guarda los cambios realizados en el editor
        UnityEditor.EditorUtility.SetDirty(target);
    }
    public override void OnInspectorGUI()
    {
        Spawner Spawner = (Spawner)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Details");
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Debug commands");
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Create"))
        {
            //Spawner.SpawnPointNumber = 1;
            Spawner.AddTeamFields(Spawner
                .SpawnPointNumber
                , Spawner.SpawnPointPrefab);
        }
        if (GUILayout.Button("Create all at once"))
        {
            Spawner.AddAllSpawnPointsAtOnce
                (
                    Spawner.SpawnPointNumber
                    , Spawner.SpawnPointPrefab
                );
        }
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("remove Last"))
        {
            Spawner.RemoveLastSpawnPoint();
        }
        
        if (GUILayout.Button("Clear"))
        {
            Spawner.ClearSpawnPoints();
        }
        
    }
}