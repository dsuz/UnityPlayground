using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("Playground/Actions/Load Level")]
[HelpURL("https://bit.ly/3yoCerb")]
public class LoadLevelAction : Action
{
    public string levelName = SAME_SCENE;

    public const string SAME_SCENE = "0";

    //Loads a new Unity scene, or reload the current one (it means all objects are reset)
    //別のシーンをロードするか、もしくは現在のシーンをリロードする。リロードすると全てのオブジェクトはリセットされる。
    public override bool ExecuteAction(GameObject dataObject)
    {
        if (levelName == SAME_SCENE)
        {
            //just restart the level
            //現在のシーンをリロードする
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
        else
        {
            //load another scene
            //別のシーン（指定されたシーン）をロードする
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }

        return true;
    }
}