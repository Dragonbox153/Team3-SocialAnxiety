using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float followSpeed = 3f;
    public Transform target;
    [SerializeField] int[] camSize ={8,7,6,5,4};
    private int zoom;

    Camera cam;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        float stressLevel = Player.gameObject.GetComponent<PlayerMovements>().stressLevel;
        Vector3 newPos= new Vector3(target.position.x,target.position.y,-2);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed*Time.deltaTime);
        Debug.Log(stressLevel);
        if (stressLevel <= 20)
        {
            zoom = 1;
            cam.orthographicSize = 8f;
        }
        else if (stressLevel > 20 && stressLevel <= 40)
        {
            zoom = 2;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - 0.1f * Time.deltaTime, camSize[0], camSize[1]);
        }
        else if (stressLevel > 40 && stressLevel <= 60)
        {
            zoom = 3;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - 0.1f * Time.deltaTime, camSize[1], camSize[2]);
        }
        else if (stressLevel > 60 && stressLevel <= 80)
        {
            zoom = 4;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - 0.1f * Time.deltaTime, camSize[2], camSize[3]);
        }
        else if (stressLevel > 80 && stressLevel <=99)
        {
            zoom = 5;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - 0.1f * Time.deltaTime, camSize[3], camSize[4]);
        }

    }
}
