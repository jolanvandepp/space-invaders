using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;

    public GameObject shot;
    public float fireRate = 0.997f;

    void Start()
    {
        InvokeRepeating("Enemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -10.5 || enemy.position.x > 10.5) {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }
        }

    }



}