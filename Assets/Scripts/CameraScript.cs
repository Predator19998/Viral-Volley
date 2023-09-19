using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 orgTransformPos;
    Vector3 orgTransformAng;
    // Start is called before the first frame update
    void Start()
    {
        orgTransformPos = transform.position;
        orgTransformAng = transform.eulerAngles;



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = new Vector3(10, 50, 25);
            transform.eulerAngles = new Vector3(90, 0, 0);
        }
        else
        {

            transform.position = orgTransformPos;
            transform.eulerAngles = orgTransformAng;
        }
    }
}

