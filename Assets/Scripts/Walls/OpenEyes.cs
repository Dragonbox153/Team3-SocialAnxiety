using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEyes : MonoBehaviour
{
    PlayerMovements player;
    [SerializeField] GameObject openEyes;
    [SerializeField] GameObject closeEyes;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.stressLevel >= 50)
        {
            openEyes.SetActive(true);
            closeEyes.SetActive(false);
        }
        else
        {
            openEyes.SetActive(false);
            closeEyes.SetActive(true);
        }
    }
}
