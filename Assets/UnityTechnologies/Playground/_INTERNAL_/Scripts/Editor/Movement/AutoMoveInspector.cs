using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AutoMove))]
public class AutoMoveInspector : InspectorBase
{
    //private string explanation = "The GameObject moves automatically in a specific direction.";
    private string explanation = "オブジェクトを指定した方向に動かす。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();
    }
}