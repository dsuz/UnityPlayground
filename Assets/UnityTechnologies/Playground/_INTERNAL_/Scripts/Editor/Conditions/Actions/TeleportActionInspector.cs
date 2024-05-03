using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(TeleportAction))]
public class TeleportActionInspector : InspectorBase
{
    //private string explanation = "Use this script to teleport this or another object to a new location.";
    private string explanation = "指定したオブジェクトを指定した座標に瞬間移動させる。";
    //private string objectWarning = "WARNING: If you don't assign a GameObject, this GameObject will be teleported!";
    private string objectWarning = "オブジェクトを割り当てない場合は、このオブジェクトが瞬間移動します。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        GUILayout.Space(10);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("objectToMove"));

        if (!CheckIfAssigned("objectToMove", false))
        {
            EditorGUILayout.HelpBox(objectWarning, MessageType.Warning);
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("newPosition"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("stopMovements"));

        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}
