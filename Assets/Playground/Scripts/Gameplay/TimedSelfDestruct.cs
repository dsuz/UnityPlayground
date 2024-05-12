using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Gameplay/Timed Self-Destruct")]
[HelpURL("https://bit.ly/3wuPJVW")]
public class TimedSelfDestruct : MonoBehaviour
{
    // After this time, the object will be destroyed
    // この秒数が経過した時にオブジェクトを破棄する
    public float timeToDestruction;

    void Start()
    {
        Invoke("DestroyMe", timeToDestruction);
    }

    // This function will destroy this object :(
    void DestroyMe()
    {
        Destroy(gameObject);

        // Bye bye!
    }
}
