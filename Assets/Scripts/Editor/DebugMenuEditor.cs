using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DebugMenu))]
public class DebugMenuEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        //EditorGUILayout.HelpBox("This is a help box", MessageType.Info);

        DebugMenu myScript = (DebugMenu)target;
        if (GUILayout.Button("Complete Riddle 1"))
        {
            myScript.SolveRiddle1();
        }

        if (GUILayout.Button("Complete Riddle 2"))
        {
            myScript.SolveRiddle2();
        }

        if (GUILayout.Button("Complete Riddle 3"))
        {
            myScript.SolveRiddle3();
        }
    }
}
