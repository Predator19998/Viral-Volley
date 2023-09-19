using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectOrCure : MonoBehaviour
{
    public bool isHit = false;
    public bool isInfected = false;
    public bool isCured = false;

    public Material infectedMaterial;
    public Material cureMaterial;
    public Material defaultMaterial;

    void Update()
    {
        if(isInfected)
        {
            GetComponent<MeshRenderer>().material = infectedMaterial;
        }
        else if(isCured)
        {
            GetComponent<MeshRenderer>().material = cureMaterial;
        }
        else
        {
            GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }

    public void FindAdjacentPlanes()
    {
        string name = transform.name;
        int rowNumber = int.Parse(name.Substring(5, 1));
        int columnNumber = int.Parse(name.Substring(6, 1));

        Transform[] parentObjectTransform = gameObject.transform.parent.gameObject.GetComponentsInChildren<Transform>();

        foreach(Transform childTransform in parentObjectTransform)
        {
            if(childTransform.name.Contains((rowNumber+1).ToString() + columnNumber.ToString()) ||
               childTransform.name.Contains(rowNumber.ToString() + (columnNumber+1).ToString()) ||
               childTransform.name.Contains((rowNumber - 1).ToString() + columnNumber.ToString()) ||
               childTransform.name.Contains(rowNumber.ToString() + (columnNumber-1).ToString())
               )
            {
                Debug.Log("Adjacent plane:"+childTransform.name);
                if(isCured)
                {
                    childTransform.GetComponent<InfectOrCure>().isCured = true;
                }
                else if(isInfected && !isCured)
                {
                    childTransform.GetComponent<InfectOrCure>().isInfected = false;
                }
            }
        }
        
    }
}
