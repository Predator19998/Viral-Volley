using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurn : MonoBehaviour
{
    public int turn = 0;
    public Transform gridObject;

    public void ChangeTurn()
    {
        StartCoroutine(TurnDelay());
    }

    IEnumerator TurnDelay()
    {
        yield return new WaitForSeconds(5);

        GameObject.Find("cannon").transform.GetComponent<CapsuleFire>().ammo = 1;

        Transform[] grids = gridObject.transform.GetComponentsInChildren<Transform>();

        foreach (Transform childGrid in grids)
        {
            if (!childGrid.name.Equals("Grids"))
            {
                if (childGrid.GetComponent<InfectOrCure>().isInfected || (childGrid.GetComponent<InfectOrCure>().isCured && childGrid.GetComponent<InfectOrCure>().isHit))
                {
                    childGrid.GetComponent<InfectOrCure>().FindAdjacentPlanes();
                }
            }
        }

        turn++;
    }
}
