using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTurn : MonoBehaviour
{
    public int turn;
    public Transform gridObject;
    Transform[] grids;

    public Text turnText;
    public Text curedText;
    public Text infectedText;

    private void Start()
    {

        turn = 1;
        grids = gridObject.transform.GetComponentsInChildren<Transform>();

        for(int i = 0;i < 2; i++)
        {
            string rnd = Random.Range(1, 6).ToString();
            foreach (Transform childGrid in grids)
            {
                if (childGrid.name.Contains(rnd+rnd))
                {
                    Debug.Log("Ground zero:" + childGrid.name);
                    childGrid.GetComponent<InfectOrCure>().groundZero = true;
                }
            }
        }

    }

    public void Update()
    {
        int cured = 0;
        int infected = 0;
        foreach (Transform childGrid in grids)
        {
            if(!childGrid.name.Equals("Grids"))
            {
                if (childGrid.GetComponent<InfectOrCure>().isInfected) infected++;
                else if (childGrid.GetComponent<InfectOrCure>().isCured) cured++;
            }
        }

        turnText.text = turn.ToString();
        curedText.text = cured.ToString();
        infectedText.text = infected.ToString();
    }

    public void ChangeTurn()
    {
        StartCoroutine(TurnDelay());
    }

    IEnumerator TurnDelay()
    {
        yield return new WaitForSeconds(5);

        GameObject.Find("cannon").transform.GetComponent<CapsuleFire>().ammo = 1;

        foreach (Transform childGrid in grids)
        {
            if (!childGrid.name.Equals("Grids"))
            {
                InfectOrCure requiredGrid = childGrid.GetComponent<InfectOrCure>();

                if (requiredGrid.isInfected && requiredGrid.groundZero)
                {
                    requiredGrid.FindAdjacentPlanes(turn);
                }
                else if(requiredGrid.isCured && requiredGrid.isHit)
                {
                    requiredGrid.FindAdjacentPlanes(1);
                }
            }
        }

        turn = turn+1;
    }
}
