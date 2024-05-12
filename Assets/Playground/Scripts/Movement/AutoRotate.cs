using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Auto Rotate")]
[HelpURL("https://bit.ly/3UG7SrM")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoRotate : Physics2DObject
{

    // This is the force that rotate the object every frame
    public float rotationSpeed = 5;

    private float currentRotation;


    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // Find the right rotation, according to speed
        // まず rotation のみを計算する
        currentRotation += .02f * rotationSpeed * 10f;

        // Apply the rotation to the Rigidbody2d
        // 計算した rotation をオブジェクトに適用する。Transform ではなく Rigidbody を使って回転させると、衝突する場合は回転が妨げられる。
        rigidbody2D.MoveRotation(-currentRotation);
    }

    //Draw an arrow to show the direction in which the object will rotate
    // オブジェクトが回転する方向を gizmo として表示する
    void OnDrawGizmosSelected()
    {
        if (this.enabled)
        {
            Utils.DrawRotateArrowGizmo(transform.position, rotationSpeed);
        }
    }
}
