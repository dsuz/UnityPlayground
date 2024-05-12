using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Teleport")]
[HelpURL("https://bit.ly/3WDQned")]
public class TeleportAction : Action
{
    public GameObject objectToMove;
    public Vector2 newPosition;
    public bool stopMovements = true;

    // Moves the GameObject instantly to a custom position
    //オブジェクトを指定された場所に瞬間移動させる
    public override bool ExecuteAction(GameObject dataObject)
    {
        Rigidbody2D rb2D;

        if (objectToMove != null)
        {
            //moves the specified object
            //指定されたオブジェクトを移動させる
            objectToMove.transform.position = newPosition;
            rb2D = objectToMove.GetComponent<Rigidbody2D>();
        }
        else
        {
            //moves this object
            //このオブジェクト（自分自身）を移動させる
            transform.position = newPosition;
            rb2D = transform.GetComponent<Rigidbody2D>();
        }

        //in case the object has physics, we can bring it to an halt
        //オブジェクトが Rigidbody2D コンポーネントを持っていて、StopMovement にチェックが入っている場合は、移動した後に動きを止める
        if (stopMovements && rb2D != null)
        {
            rb2D.velocity = Vector3.zero;
            rb2D.angularVelocity = 0f;
        }

        return true;
    }
}
