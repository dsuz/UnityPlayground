using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIScript))]
public class UIScriptInspector : InspectorBase
{
    //private string explanation = "Use the UI to visualise points and health for the players.";
    private string explanation = "得点とライフを表示する。";
    //private string lifeReminder = "Don't forget to use the script HealthSystemAttribute on the player(s)!";
    private string lifeReminder = "Player/Player2 いずれかの Health System の Health が 0 になるとゲームが終了する。";

    private int nOfPlayers = 0, gameType = 0;
    private string[] readablePlayerEnum = new string[] { "One player", "Two players" };
    private string[] readableGameTypesEnum = new string[] { "Score", "Life", "Endless" };

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        nOfPlayers = serializedObject.FindProperty("numberOfPlayers").intValue;
        gameType = serializedObject.FindProperty("gameType").intValue;

        nOfPlayers = EditorGUILayout.Popup("Number of players", nOfPlayers, readablePlayerEnum);

        gameType = EditorGUILayout.Popup("Game type", gameType, readableGameTypesEnum);
        if (gameType == 0) //score game
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("scoreToWin"));
        }

        if (gameType == 1) //life
        {
            EditorGUILayout.HelpBox(lifeReminder, MessageType.Info);
        }

        //write all the properties back
        serializedObject.FindProperty("gameType").intValue = gameType;
        serializedObject.FindProperty("numberOfPlayers").intValue = nOfPlayers;

        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}
