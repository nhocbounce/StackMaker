using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelController))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelController myScript = (LevelController)target;

        if (GUILayout.Button("LevelCreator"))
        {
            myScript.DrawLevel();
        }
        
        if (GUILayout.Button("Save"))
        {
            myScript.SaveLevel();
        }
        if (GUILayout.Button("ResetData"))
        {
            myScript.ResetLevelData();
        }
    }
}
