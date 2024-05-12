using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Follow Target")]
[HelpURL("https://bit.ly/4bxW81w")]
[RequireComponent(typeof(Rigidbody2D))]
public class FollowTarget : Physics2DObject
{
    // This is the target the object is going to move towards
    // このオブジェクトが追いかけるターゲット
    public Transform target;

    [Header("Movement")]
    // Speed used to move towards the target
    // ターゲットに向かうスピード
    public float speed = 1f;

    // Used to decide if the object will look at the target while pursuing it
    // true の時、ターゲットの方向を向く
    public bool lookAtTarget = false;

    // The direction that will face the target
    // ターゲットに向ける方向
    public Enums.Directions useSide = Enums.Directions.Up;

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //do nothing if the target hasn't been assigned or it was detroyed for some reason
        // ターゲットが割り当てられていない場合や、ターゲットが既に破棄されている時は何もしない
        if (target == null)
            return;

        //look towards the target
        // ターゲットの方を向く
        if (lookAtTarget)
        {
            Utils.SetAxisTowards(useSide, transform, target.position - transform.position);
        }

        //Move towards the target
        // ターゲットに向かって移動する
        rigidbody2D.MovePosition(Vector2.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed));
    }
}
