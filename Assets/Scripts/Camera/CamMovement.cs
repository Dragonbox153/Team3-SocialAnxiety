using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CamMovement : MonoBehaviour
{
    public float followSpeed = 3f;
    public Transform target;
    public float[] camSize ={8,6,4,2,1};
    static float t = 0.0f;
    Camera cam;
    public GameObject Player;
    private int zoom;
    private int oldZoom;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        oldZoom = 1;
    }



    // Update is called once per frame
    void Update()
    {
        // camera tracking the player and moving
        Vector3 newPos= new Vector3(target.position.x,target.position.y,-2);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed*Time.deltaTime);

        // getting value of stress from player script
        float stressLevel = Player.gameObject.GetComponent<PlayerMovements>().stressLevel;

        if (zoom != oldZoom)
        {
            t = 0.0f;
            oldZoom = zoom; // Update previous zoom to the current one
        }

        // Chainging camera size
        if (stressLevel <= 20)
        {
            zoom = 1;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSize[0], t);
            t += 0.01f * Time.deltaTime;
        }
        else if (stressLevel > 20 && stressLevel <= 40)
        {
            zoom = 2;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSize[1], t);
            t += 0.01f * Time.deltaTime;
        }
        else if (stressLevel > 40 && stressLevel <= 60)
        {
            zoom = 3;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSize[2], t);
            t += 0.01f * Time.deltaTime;
        }
        else if (stressLevel > 60 && stressLevel <= 80)
        {
            zoom = 4;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSize[3], t);
            t += 0.01f * Time.deltaTime;
        }
        else if (stressLevel > 80 && stressLevel <=99)
        {
            zoom = 5;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSize[4], t);
            t += 0.01f * Time.deltaTime;
        }
    }
}