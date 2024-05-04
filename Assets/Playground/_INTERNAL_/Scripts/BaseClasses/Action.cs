using UnityEngine;
using System.Collections;
using System;

public abstract class Action : MonoBehaviour
{
    public virtual bool ExecuteAction(GameObject other)
    {
        //the return value indicates if the action has been successful
        //some actions always return true
        //戻り値はアクションが成功したかどうかを意味する。常にtrue（成功）を返すアクションもある。
        return true;
    }
}
