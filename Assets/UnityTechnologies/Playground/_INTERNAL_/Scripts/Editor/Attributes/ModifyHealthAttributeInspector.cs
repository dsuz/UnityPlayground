using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ModifyHealthAttribute))]
public class ModifyHealthAttributeInspector : InspectorBase
{
    //private string explanation = "This GameObject will damage or heal other GameObjects on impact (only if they use the HealthSystemAttribute). Negative values mean damage, positive values mean healing (like a medipack).";
    private string explanation = "このオブジェクトは、接触してきた相手のオブジェクトにダメージを与える、もしくは回復させる。\nただし、Health System コンポーネントが 相手のオブジェクトに 追加されていなければならない。\n負の値はダメージになり、正の値は回復になる。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();

        //print a message to explain better that values can be positive or negative
        GUIStyle style = new GUIStyle(EditorStyles.label);

        if (serializedObject.FindProperty("healthChange").intValue < 0)
        {
            style.normal.textColor = Color.red;
            //EditorGUILayout.LabelField("This object will damage on impact", style);
            EditorGUILayout.LabelField("このオブジェクトに接触するとダメージを受ける", style);
        }
        else if (serializedObject.FindProperty("healthChange").intValue > 0)
        {
            style.normal.textColor = Color.blue;
            //EditorGUILayout.LabelField("This object will heal on impact", style);
            EditorGUILayout.LabelField("このオブジェクトに接触すると回復する", style);
        }
        else
        {
            //EditorGUILayout.LabelField("This object will have no effect");
            EditorGUILayout.LabelField("このオブジェクトは効果がない");
        }
    }
}
