﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Gameplay/Object Creator Area")]
[HelpURL("https://bit.ly/3JYYYka")]
[RequireComponent(typeof(BoxCollider2D))]
public class ObjectCreatorArea : MonoBehaviour
{
    [Header("Object creation")]

    // The object to spawn
    //生成するオブジェクト
    // WARNING: take if from the Project panel, NOT the Scene/Hierarchy!
    //注）Hierarchy にあるオブジェクト（シーン上のオブジェクト）を割り当てるのではなく、Project ウインドウにあるプレハブを指定すること
    public GameObject prefabToSpawn;

    [Header("Other options")]

    // Configure the spawning pattern
    //生成する間隔（秒）を指定する
    public float spawnInterval = 1;

    private BoxCollider2D boxCollider2D;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        StartCoroutine(SpawnObject());
    }

    // This will spawn an object, and then wait some time, then spawn another...
    //ここでオブジェクトを生成→待ち→オブジェクト生成→待ち→...を繰り返す
    IEnumerator SpawnObject()
    {
        while (true)
        {
            // Create some random numbers
            // 範囲内でランダムな座標を求める
            float randomX = Random.Range(-boxCollider2D.size.x, boxCollider2D.size.x) * .5f;
            float randomY = Random.Range(-boxCollider2D.size.y, boxCollider2D.size.y) * .5f;

            // Generate the new object
            // オブジェクトを生成し、計算した座標に移動する
            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            newObject.transform.position = new Vector2(randomX + this.transform.position.x, randomY + this.transform.position.y);

            // Wait for some time before spawning another object
            // 処理をループさせる前に待つ
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
