using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Rotate))]
public class RotateInspector : InspectorBase
{
    //private string explanation = "The GameObject rotates when pressing the Arrow keys or WASD.";
    private string explanation = "カーソルキー（矢印キー）の左右、または AD キーを押した時にオブジェクトを回転させる。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();
    }
}