using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Jump))]
public class JumpInspector : InspectorBase
{
    //private string explanation = "Makes the GameObject jump at the press of a button.";
    private string explanation = "指定したボタンを押した時に、オブジェクトをジャンプさせる。";
    private bool checkGround;
    //private string checkGroundTip = "Enable ground check to restrict the Player from jumping while in the air.";
    private string checkGroundTip = "Check ground にチェックを入れると、地面の上に立っている時だけジャンプする。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("key"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("jumpStrength"));


        GUILayout.Label("Ground setup", EditorStyles.boldLabel);
        checkGround = EditorGUILayout.Toggle("Check ground", serializedObject.FindProperty("checkGround").boolValue);
        if (checkGround)
        {
            serializedObject.FindProperty("groundTag").stringValue = EditorGUILayout.TagField("Ground tag", serializedObject.FindProperty("groundTag").stringValue);
        }
        else
        {
            EditorGUILayout.HelpBox(checkGroundTip, MessageType.Info);
        }
        serializedObject.FindProperty("checkGround").boolValue = checkGround;

        serializedObject.ApplyModifiedProperties();
    }
}