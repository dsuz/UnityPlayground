using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(TimedSelfDestruct))]
public class TimedSelfDestructInspector : InspectorBase
{
    //private string explanation = "This GameObject will self destruct after a set amount of time, useful for bullets so they don't accumulate.";
    private string explanation = "指定した秒数後にこのオブジェクトを破棄する。弾に追加しておくと、弾のオブジェクトがシーンに溜まり続けることがなくなる。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();
    }
}
