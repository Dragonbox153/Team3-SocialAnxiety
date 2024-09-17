using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CamMovement : MonoBehaviour
{
    public float followSpeed = 3f;
    public Transform target;
    private float[] camSize ={8,7,6,5,4};
    static float t = 0.0f;
    Camera cam;
    public GameObject Player;

    private int variableValue;
    private int isIncreasing=0;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public int zoom
    {
        get
        {
            return variableValue;
        }
        set
        {
            if (value > variableValue)
            {
                isIncreasing = 1;
            }
            else if (value < variableValue)
            {
                isIncreasing = -1;
            }
            else
            {
                isIncreasing = 0;
            }
            variableValue = value;
            //isIncreasing = variableValue <= value;
            //variableValue = value;
        }
    }


    // Update is called once per frame
    void Update()
    {

        Vector3 newPos= new Vector3(target.position.x,target.position.y,-2);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed*Time.deltaTime);


        float stressLevel = Player.gameObject.GetComponent<PlayerMovements>().stressLevel;
        if (t > 1.0f)
        {
            t = 0.0f;
        }
        if (stressLevel <= 20)
        {
            zoom = 1;
            //cam.orthographicSize = camSize[0];
        }
        else if (stressLevel > 20 && stressLevel <= 40)
        {
            zoom = 2;
            //cam.orthographicSize = Mathf.Lerp(camSize[0], camSize[1],t);
            //t += 0.5f * Time.deltaTime;
            //cam.orthographicSize = camSize[1];
        }
        else if (stressLevel > 40 && stressLevel <= 60)
        {
            zoom = 3;
            //cam.orthographicSize = Mathf.Lerp(camSize[1], camSize[2], t);
            //t += 0.5f * Time.deltaTime;
            //cam.orthographicSize = camSize[2];  
        }
        else if (stressLevel > 60 && stressLevel <= 80)
        {
            zoom = 4;
            //cam.orthographicSize = camSize[3];
        }
        else if (stressLevel > 80 && stressLevel <=99)
        {
            zoom = 5;
            //cam.orthographicSize = camSize[4];
        }
        Debug.Log(isIncreasing);
        if(isIncreasing ==0)
        {

        }
        else if (isIncreasing > 0 && zoom>=2)
        {
            cam.orthographicSize = Mathf.Lerp(camSize[zoom-2], camSize[zoom-1],t);
            t += 0.5f * Time.deltaTime;
        }
    }
}
