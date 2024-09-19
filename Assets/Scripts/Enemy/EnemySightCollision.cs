using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightCollision : MonoBehaviour
{
    [SerializeField] int stressIncrease = 2;
    [SerializeField] float timeToIncrease = 0.5f;
    [SerializeField] PlayerMovements Player;
    float time = 0;
    bool inSight = false;

    private void Update()
    {
        if(inSight && time >= timeToIncrease)
        {
            time += Time.deltaTime;
            Player.stressLevel += stressIncrease;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inSight = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        inSight = false;
        time = 0;
    }
}
