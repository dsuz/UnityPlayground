using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectCreatorArea))]
public class ObjectCreatorAreaInspector : InspectorBase
{
    //private string explanation = "Creates an object repeatedly in a square area. The size of the area is defined by the size of BoxCollider2D, while Spawn Interval defines the delay of spawning.";
    private string explanation = "矩形の範囲にオブジェクトを繰り返し生成する。矩形の範囲は BoxCollider2D によって指定する。Spawn Interval には生成される間隔(秒)を指定する。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        ShowPrefabWarning("prefabToSpawn");

        base.OnInspectorGUI();

        CheckIfTrigger(true);
    }
}
