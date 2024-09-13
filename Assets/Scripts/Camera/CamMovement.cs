using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float followSpeed = 3f;
    public Transform target;
    [SerializeField] int[] camSize ={1,2,3,4,5};

    Camera cam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos= new Vector3(target.position.x,target.position.y,-2);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed*Time.deltaTime);
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + 0.1f*Time.deltaTime, camSize[0],camSize[1]);
    }
}
