using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class sphere : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float xHorizontal = Input.GetAxis("Horizontal");
        float zVertical = Input.GetAxis("Vertical");
        Vector3 moveSystem = new Vector3(xHorizontal, 0.0f, zVertical);
        transform.position += moveSystem * speed * Time.deltaTime;
    }
}
   
    