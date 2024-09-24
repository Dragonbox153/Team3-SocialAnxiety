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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onred = true;
            Debug.Log("HI");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onred = false;

        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (onred && time>=timeToIncrease && player.gameObject.GetComponent<PlayerMovements>().stressLevel<=100)
        {
            time = 0;
            player.gameObject.GetComponent<PlayerMovements>().stressLevel +=stressIncrease;
            Debug.Log(player.gameObject.GetComponent<PlayerMovements>().stressLevel);
        }
    }
}
