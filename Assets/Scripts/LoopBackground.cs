using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float midpoint;

    void Start()
    {
        startPos = transform.position;
        midpoint = (GetComponent<BoxCollider>().size.x / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - midpoint)
        {
            transform.position = startPos;
        }
    }
}
