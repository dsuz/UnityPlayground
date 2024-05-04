using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(PickUpAndHold))]
public class PickUpAndHoldInspector : InspectorBase
{
    //private string explanation = "The Player can pick up and drop objects by pressing a key.";
    private string explanation = "このコンポーネントを追加したオブジェクトは、他のオブジェクトをつかんだり離したりできる。";
    //private string warning = "The Pickup object must be tagged 'Pickup' and have component Rigidbody2D";
    private string warning = "つかむ・離す対象のオブジェクトには Rigidbody2D を追加し、Pickup タグを設定すること。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        GUILayout.Space(10);
        base.OnInspectorGUI();
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(warning, MessageType.Warning);
    }
}
