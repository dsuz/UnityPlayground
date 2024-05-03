using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectShooter))]
public class ObjectShooterInspector : InspectorBase
{
    //private string explanation = "Spawns an object at the press of a button and it applies a force to it in the direction chosen.";
    private string explanation = "ボタンを押した時にオブジェクトを生成し、指定された方向に力を加える。";
    //private string hint = "TIP: If you want to shoot in another direction, apply this script to a child object and rotate it in the direction you want.";
    //private string warning = "WARNING: Don't forget to apply a Rigidbody2D to your projectiles, or they won't move!";
    private string warning = "発射するオブジェクトに Rigidbody2D コンポーネントが追加されていません。Rigidbody2D がないと、力を加えることができず、動きません。";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        bool prefabSelected = ShowPrefabWarning("prefabToSpawn");

        if (prefabSelected)
        {
            if (!CheckIfObjectUsesComponent<Rigidbody2D>("prefabToSpawn"))
            {
                EditorGUILayout.HelpBox(warning, MessageType.Warning);
            }
        }

        base.OnInspectorGUI();

        //removed because it's not possible to choose the direction
        //EditorGUILayout.HelpBox(hint, MessageType.Info);
    }
}
