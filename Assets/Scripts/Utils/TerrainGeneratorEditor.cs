using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainGenerator2))]
public class TerrainGeneratorEditor : Editor {

    public override void OnInspectorGUI () {

        TerrainGenerator2 gen = (TerrainGenerator2)target;

        DrawDefaultInspector();

        if(GUILayout.Button("GENERATE")) {
            gen.GenerateTerrain();
        }

        if(GUILayout.Button("TREES")) {
            gen.PlaceTrees();
        }
    }
}
