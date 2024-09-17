using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.transform.GetChild(0).GetComponent<PlayerMovements>().stressLevel++;
        }
    }
}
