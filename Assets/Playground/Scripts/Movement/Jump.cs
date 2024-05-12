using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Jump")]
[HelpURL("https://bit.ly/4bDhnz3")]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : Physics2DObject
{
    [Header("Jump setup")]
    // the key used to activate the push
    // ジャンプするキー
    public KeyCode key = KeyCode.Space;

    // strength of the push
    // ジャンプ力
    public float jumpStrength = 10f;

    [Header("Ground setup")]
    //if the object collides with another object tagged as this, it can jump again
    // このタグがついたオブジェクトに衝突したら、もう一度ジャンプできる
    public string groundTag = "Ground";

    //this determines if the script has to check for when the player touches the ground to enable him to jump again
    // true の時は、着地するまでジャンプできない。つまり空中ではジャンプできない。
    //if not, the player can jump even while in the air
    // false の時は、空中で何度でもジャンプできる
    public bool checkGround = true;

    private bool canJump = true;

    // Read the input from the player
    void Update()
    {
        if (canJump
            && Input.GetKeyDown(key))
        {
            // Apply an instantaneous upwards force
            // Impulse オプションを付けて、瞬間的に上向きの力を加える
            rigidbody2D.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            canJump = !checkGround;
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        if (checkGround
            && collisionData.gameObject.CompareTag(groundTag))
        {
            canJump = true;
        }
    }
}