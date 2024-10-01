using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OpenEyes : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tilemap closed;
    [SerializeField] Tilemap open;

    PlayerMovements player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.stressLevel >= 50)
        {
            tilemap = open;
        }
        else
        {
            tilemap = closed;
        }
    }
}
