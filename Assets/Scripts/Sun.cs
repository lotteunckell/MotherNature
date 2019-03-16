using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Vector3 pos;
    public int scale;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position.x;
        //Vector3 p = transform.position;
        pos = new Vector3 ( 7, 7, 14);
        transform.position = pos;
        scale = 15;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 posEarth = Earth.transform.position;
    }
}
