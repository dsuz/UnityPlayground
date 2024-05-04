using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AutoRotate))]
public class AutoRotateInspector : InspectorBase
{
    //private string explanation = "The GameObject rotates automatically.";
    private string explanation = "オブジェクトを回転させる。";
    //private string tip = "TIP: Use negative value to rotate in the other direction.";
    private string tip = "負の値を指定すると、逆方向に回転する。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();

        EditorGUILayout.HelpBox(tip, MessageType.Info);
    }
}