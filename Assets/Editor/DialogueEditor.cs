using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
using Codice.CM.Common;
using UnityEditor.UIElements;
using System.Web.UI.WebControls;

[CustomEditor(typeof(EditorTest))]
public class DialogueEditor : Editor
{
    EditorTest editorTest;
    private void OnEnable()
    {
        editorTest = target as EditorTest; 
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        var myObj = (MyTest)serializedObject.FindProperty("_enumTest").intValue;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_test4"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_enumTest"));

        serializedObject.ApplyModifiedProperties();
    }
}
