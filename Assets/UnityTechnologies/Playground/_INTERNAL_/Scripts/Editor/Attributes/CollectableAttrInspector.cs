using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(CollectableAttribute))]
public class CollectableAttrInspector : InspectorBase
{
    //private string explanation = "When the Player touches this object, it will be awarded one or more points.";
    private string explanation = "Player タグを指定したオブジェクトがこのオブジェクトに接触すると、得点が入る。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();

        CheckIfTrigger(true);
    }
}
