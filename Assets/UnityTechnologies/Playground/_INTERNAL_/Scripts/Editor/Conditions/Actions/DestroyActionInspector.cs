using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(DestroyAction))]
public class DestroyActionInspector : InspectorBase
{
    //private string explanation = "Destroys a GameObject instantaneously on impact. Could be this object, or the one that suffered the impact.";
    private string explanation = "衝突時にオブジェクトを破棄する。このオブジェクトを破棄するか、このオブジェクトに衝突してきた相手のどちらを破棄するか選べる。";
    //private string tip = "TIP: You can assign a death effect, such as an explosion or another particle system.";
    private string tip = "オブジェクトが破棄される時に再生されるエフェクトを指定できる。爆発もしくは他のパーティクルを指定できる。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();

        if (!CheckIfAssigned("deathEffect", true))
        {
            EditorGUILayout.HelpBox(tip, MessageType.Info);
        }
    }
}
