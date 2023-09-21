using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleFire : MonoBehaviour
{
    public Transform projectilePoint;
    public GameObject projectile;

    public float ammo = 1;
    public float speed;
    public float maxSpeed = 25;
    bool startFire = false;

    float initialSpeed;

    private void Start()
    {
        initialSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && ammo>0)
        {
            if(speed <= maxSpeed)
            {
                startFire = true;
                speed += Time.deltaTime * 2;
            }
        }

        if(Input.GetMouseButtonUp(0) && startFire)
        {
            var bullet = Instantiate(projectile, projectilePoint.position, projectilePoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = speed * projectilePoint.transform.up;
            ammo--;
            startFire = false;
            speed = initialSpeed;
        }
    }
}
