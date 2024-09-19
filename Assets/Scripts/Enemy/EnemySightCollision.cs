using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightCollision : MonoBehaviour
{
    [SerializeField] int stressIncrease = 2;
    [SerializeField] float timeToIncrease = 0.5f;
    float time = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        time += Time.deltaTime;
        if (collision.tag == "Player" && time >= timeToIncrease)
        {
            collision.gameObject.GetComponent<PlayerMovements>().stressLevel += stressIncrease;
            time = 0;
        }
    }
}
