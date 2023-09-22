using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = new Vector3(10, 55, 25);
            transform.eulerAngles = new Vector3(90, 0, 0);
        }
        else
        {

            transform.position = GameObject.Find("cameraLoc").transform.position;
            transform.eulerAngles = GameObject.Find("cameraLoc").transform.eulerAngles;
        }
    }
}

