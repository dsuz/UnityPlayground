using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public abstract class ConditionBase : MonoBehaviour
{
    //actionitems can be connected to GameplayAction scripts, and execute their one action (the method ExecuteAction implemented in each child class)
    //actions には設定された Action が格納される。各 Action で実行すべき処理が実行される。各 Action の ExecuteAction メソッドで、実行すべき処理が実装されている。
    [SerializeField]
    public List<Action> actions = new List<Action>();

    //custom actions are more complicated to setup but more powerful, and appear only if useCustomActions is enabled
    //Custom Action としてデリゲートを割り当てることができる
    public bool useCustomActions = false;
    public UnityEvent customActions;

    //to perform the actions only once
    //true の時は Action を一度しか実行しない
    public bool happenOnlyOnce = false;
    private bool alreadyHappened = false;

    public bool filterByTag = false;
    public string filterTag = "Player";

    //dataObject is usually the other object in the collision
    //引数 dataObject では衝突相手のオブジェクトが渡されることを想定している
    public void ExecuteAllActions(GameObject dataObject)
    {
        //first check if the action has already been executed
        //まず、実行すべき Action を実行すべきか判定する
        if (happenOnlyOnce && alreadyHappened)
            return;

        //first execute the simple GameplayActions, if present
        //先に Playground の Action から実行する
        bool actionResult;
        foreach (Action ga in actions)
        {
            if (ga != null)
            {
                actionResult = ga.ExecuteAction(dataObject);
                if (actionResult == false)
                {
                    //Debug.LogWarning("An action failed and interrupted the chain of Actions");
                    Debug.LogWarning($"{this.gameObject.name} オブジェクトに追加された {this.GetType().Name} コンポーネントの {ga.name} が fail を返しました。\nそれより後の Action は実行されません。");
                    return;
                }
            }
        }

        //execute the custom actions, if present and enabled
        //その後に Custom Action を実行する
        if (useCustomActions)
        {
            customActions.Invoke();
        }

        //will prevent re-executing the actions if happenOnlyOnce is true
        //このフラグを立てておけば、一度しか実行しないように設定している場合は、再実行されないようにできる
        alreadyHappened = true;
    }
}