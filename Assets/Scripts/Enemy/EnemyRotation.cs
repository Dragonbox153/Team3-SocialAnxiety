using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).transform.localRotation = transform.rotation;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
