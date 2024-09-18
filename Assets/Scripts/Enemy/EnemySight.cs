using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemySight : MonoBehaviour
{
    RaycastHit2D hit;

    // Update is called once per frame
    void Update()
    {
        Vector2 sightPos = transform.GetChild(0).gameObject.transform.position;
        hit = Physics2D.Raycast(transform.position, sightPos, 5, LayerMask.GetMask("Default"));
        Debug.Log(transform.GetChild(0).gameObject.transform.position);
        if (hit.collider != null)
        {
            float dist = Vector2.Distance(transform.position, hit.point);
            transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, dist, 1);
        }
    }
}
