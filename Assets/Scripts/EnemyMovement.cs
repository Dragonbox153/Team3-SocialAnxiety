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
}
