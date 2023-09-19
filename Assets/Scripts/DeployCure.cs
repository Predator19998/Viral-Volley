using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCure : MonoBehaviour
{

    public Material newMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        Debug.Log("Collided with:" + collidedObject.name);
        collidedObject.GetComponent<InfectOrCure>().isCured = true;
        collidedObject.GetComponent<InfectOrCure>().isHit = true;

        Destroy(gameObject);

        Transform nextTurn = GameObject.Find("NextTurn").transform;
        if (nextTurn != null)
        {
            nextTurn.GetComponent<NextTurn>().ChangeTurn();
        }
    }

}
