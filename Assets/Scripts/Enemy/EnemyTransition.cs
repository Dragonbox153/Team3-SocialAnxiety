using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransition : MonoBehaviour
{
    [SerializeField] Animator animator;
    PlayerMovements player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.stressLevel >= 50)
        {
            animator.SetBool("Phase2", true);
        }
        else
        {
            animator.SetBool("Phase2", false);
        }
    }
}
