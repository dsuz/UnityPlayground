using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CreateObjectAction))]
public class CreateObjectActionInspector : InspectorBase
{
    //private string explanation = "Use this script to create a new GameObject from a Prefab in a specific position.";
    private string explanation = "指定した座標に、指定したプレハブを使ってオブジェクトを生成する。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        GUILayout.Space(10);
        base.OnInspectorGUI();

        ShowPrefabWarning("prefabToCreate");
    }
}
