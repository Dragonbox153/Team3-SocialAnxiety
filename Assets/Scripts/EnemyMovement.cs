using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject[] movementPoints;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float speed = 1;

    int nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = movementPoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != movementPoints[nextPoint].transform.position)
        {
            rigidbody.MovePosition(Vector2.MoveTowards(transform.position, movementPoints[nextPoint].transform.position, speed * Time.deltaTime));
        }
        else
        {
            UpdatePoint();
            RotateEnemy();
        }
    }

    void UpdatePoint()
    {
        if(nextPoint < movementPoints.Length - 1)
        {
            nextPoint++;
        }
        else
        {
            nextPoint = 0;
        }
    }

    void RotateEnemy()
    {
        Vector3 lookAt = movementPoints[nextPoint].transform.position - transform.position;
        if (lookAt.x == 0)
        {
            if (lookAt.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        else
        {
            if (lookAt.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
    }
}
