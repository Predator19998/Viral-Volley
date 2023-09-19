using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform orgTransform;
    // Start is called before the first frame update
    void Start()
    {
        orgTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = new Vector3(0,10,30);
            transform.eulerAngles = new Vector3(120, 0, 0);
        }
        else
        {
            transform.position = orgTransform.position;
            transform.rotation = orgTransform.rotation;
        }
    }
}
