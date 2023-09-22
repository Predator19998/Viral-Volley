using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCure : MonoBehaviour
{

    public bool collided = false;

    public Material newMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collided)
        {
            GameObject collidedObject = collision.gameObject;
            Debug.Log("Collided with:" + collidedObject.name);
            collidedObject.GetComponent<InfectOrCure>().isCured = true;
            collidedObject.GetComponent<InfectOrCure>().isHit = true;
            collidedObject.GetComponent<InfectOrCure>().isInfected = false;
            collidedObject.GetComponent<InfectOrCure>().groundZero = false;

            Destroy(gameObject);

            collided = true;

            Transform nextTurn = GameObject.Find("NextTurn").transform;
            nextTurn.GetComponent<NextTurn>().ChangeTurn();
        }
    }

}
