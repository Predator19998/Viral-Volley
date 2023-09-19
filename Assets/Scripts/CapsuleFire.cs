using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleFire : MonoBehaviour
{
    public Transform projectilePoint;
    public GameObject projectile;

    public float ammo = 1;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && ammo>0)
        {
            var bullet = Instantiate(projectile, projectilePoint.position, projectilePoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = speed * projectilePoint.transform.up;
            ammo--;
        }
    }
}
