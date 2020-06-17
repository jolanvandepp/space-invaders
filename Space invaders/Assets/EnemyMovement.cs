using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyHolder = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHolder.position.x <= -3.5)
        {
            MoveRight();
        }
        if (enemyHolder.position.x >= 3.5)
        {
            MoveLeft();
        }
    }

    void MoveRight() 
    {
        while (enemyHolder.position.x < 3.5)
        {
            enemyHolder.position += Vector3.right * speed;
        }
    }

    void MoveLeft()
    {
        while (enemyHolder.position.x > -3.5)
        {
            enemyHolder.position += Vector3.left * speed;
        }
    }
}
