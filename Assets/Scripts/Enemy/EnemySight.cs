using NUnit.Framework;
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
        Vector2 sightPos = transform.GetChild(0).transform.GetChild(1).gameObject.transform.position - transform.position;

        hit = Physics2D.Raycast(transform.position, sightPos, 5, 1);
        if (hit.collider != null)
        {
            float dist = Vector2.Distance(transform.position, hit.point);
            transform.GetChild(0).transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, dist, 1);
            transform.GetChild(0).transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, (dist / 2), 0);
        }
        else
        {
            transform.GetChild(0).transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 5.5f, 1);
            transform.GetChild(0).transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, (5.5f / 2), 0);
        }
    }
}
