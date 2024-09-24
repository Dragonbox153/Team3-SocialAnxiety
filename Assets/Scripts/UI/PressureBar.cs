using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureBar : MonoBehaviour
{
    [SerializeField] Sprite[] blackEyes;
    [SerializeField] Sprite[] redEyes;

    PlayerMovements player;
    int prevAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        int angle = player.stressLevel / 25;
        transform.GetChild(transform.childCount - 2).GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -angle * 45);

        if(angle != prevAngle)
        {
            transform.GetChild(prevAngle).GetComponent<Image>().sprite = redEyes[prevAngle];
        }

        prevAngle = angle;
    }
}
