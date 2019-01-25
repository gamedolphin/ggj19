using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameConfig))]
public class GameConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameConfig myScript = (GameConfig)target;
        if(GUILayout.Button("Run Server"))
        {
            myScript.RunServer();
        }

        if(GUILayout.Button("Run Client"))
        {
            myScript.RunClient();
        }
    }
}
