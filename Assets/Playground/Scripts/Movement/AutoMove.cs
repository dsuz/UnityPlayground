using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Auto Move")]
[HelpURL("https://bit.ly/4bxVQaW")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoMove : Physics2DObject
{
    // These are the forces that will push the object every frame
    // don't forget they can be negative too!
    // オブジェクトを押す力を設定する。負の値を指定することもできる。
    public Vector2 direction = new Vector2(1f, 0f);

    //is the push relative or absolute to the world?
    // グローバル座標系（ワールド座標系）の方向に押すか、ローカル座標系の方向に押すかを決定する
    public bool relativeToRotation = true;

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (relativeToRotation)
        {
            rigidbody2D.AddRelativeForce(direction * 2f);
        }
        else
        {
            rigidbody2D.AddForce(direction * 2f);
        }
    }

    //Draw an arrow to show the direction in which the object will move
    // オブジェクトが移動する方向を矢印の gizmo として表示する
    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            float extraAngle = (relativeToRotation) ? transform.rotation.eulerAngles.z : 0f;
            Utils.DrawMoveArrowGizmo(transform.position, direction, extraAngle);
        }
    }
}
