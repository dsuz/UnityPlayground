using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/On-Off")]
[HelpURL("https://bit.ly/3yq75Uj")]
public class OnOffAction : Action
{
    public GameObject objectToAffect;
    public bool justMakeInvisible;

    // Changes the object state from active to inactive, and viceversa
    //オブジェクト (GameObject) をアクティブ⇔非アクティブにしたり、SpriteRenderer を無効にしたりする
    public override bool ExecuteAction(GameObject dataObject)
    {
        if (objectToAffect != null)
        {
            if (!justMakeInvisible)
            {
                objectToAffect.SetActive(!objectToAffect.activeSelf);
            }
            else
            {
                //in this case, we just make the object invisible
                //justMakeInvisible == true の場合は、SpriteRenderer コンポーネントのみを無効にして、見えなくする
                SpriteRenderer sr = objectToAffect.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.enabled = !sr.enabled;
                }
                else
                {
                    //the object doesn't have a Sprite Renderer component so the action can't be performed!
                    //オブジェクトが SpriteRenderer を持っていない場合は、このアクションは実行できない
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}
