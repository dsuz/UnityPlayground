using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(BulletAttribute))]
public class BulletAttrInspector : InspectorBase
{
    // private string explanation = "When this object touches another that has the script DestroyForPoints, the Player will get a point.";
    private string explanation = "このオブジェクトが他の DestroyForPoints コンポーネントを追加した\nオブジェクトに接触すると、プレイヤーに点が入る。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        base.OnInspectorGUI();
    }
}
