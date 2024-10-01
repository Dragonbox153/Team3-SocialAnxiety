using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendScript : MonoBehaviour
{
    public MiniGame MiniGame;

    public Vector3 locationBeforeMiniGame;
    public Vector3 locationAfterMiniGame;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = locationBeforeMiniGame;
        if (MiniGame == null)
        {
            Debug.LogError("MiniGame reference is not assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MiniGame.gameOver) 
        {
            transform.position = locationAfterMiniGame;
        }
    }
}
