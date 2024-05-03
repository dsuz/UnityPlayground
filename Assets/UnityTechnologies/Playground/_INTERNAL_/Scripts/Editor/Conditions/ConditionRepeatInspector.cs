using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionRepeat))]
public class ConditionRepeatInspector : ConditionInspectorBase
{
    //private string explanation = "Use this script to perform an action repeatedly.";
    private string explanation = "指定した Action を繰り返し実行する。";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        GUILayout.Space(10);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("initialDelay"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("frequency"));

        GUILayout.Space(10);
        DrawActionLists();

        serializedObject.ApplyModifiedProperties();
    }
}
