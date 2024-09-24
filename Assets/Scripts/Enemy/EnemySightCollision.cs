using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightCollision : MonoBehaviour
{
    [SerializeField] int stressIncrease = 2;
    [SerializeField] float timeToIncrease = 0.5f;
    [SerializeField] PlayerMovements player;
    private bool onred;
    float time = 0;
    private void OnTriggerEntry2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            onred = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onred = false;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (onred)
        {
            player.gameObject.GetComponent<PlayerMovements>().stressLevel += stressIncrease;
            time = 0;
        }
    }
}
