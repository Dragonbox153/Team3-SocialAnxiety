using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransition : MonoBehaviour
{
    [SerializeField] Animator animator;
    PlayerMovements player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovements>();
        transform.GetChild(0).gameObject.transform.localRotation = transform.rotation;
        transform.rotation = Quaternion.Euler(0, 0, 0);
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
