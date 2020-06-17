using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    public float drop;

    public GameObject shot;
    public float fireRate = 0.997f;

    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

       
        
            if (enemyHolder.position.x <= -3.5 || enemyHolder.position.x >= 3.5) {
                speed = -speed;
                enemyHolder.position += Vector3.down * drop;
                return;
            }

        

    }



}