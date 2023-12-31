using UnityEngine;

public class InfectOrCure : MonoBehaviour
{
    public bool isHit = false;
    public bool groundZero = false;
    public bool isInfected = false;
    public bool isCured = false;

    public int hitTurn = 1;

    public Material infectedMaterial;
    public Material cureMaterial;
    public Material defaultMaterial;


    void Update()
    {
        if(groundZero)
        {
            isInfected = true;
        }

        if (isInfected)
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

    public void FindAdjacentPlanes(int spread)
    {
        string name = transform.name;
        int rowNumber = int.Parse(name.Substring(5, 1));
        int columnNumber = int.Parse(name.Substring(6, 1));

        Transform[] parentObjectTransform = gameObject.transform.parent.gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform childTransform in parentObjectTransform)
        {

            if (groundZero)
            {
                for (int i = -spread; i <= spread; i++)
                {
                    for (int j = -spread; j <= spread; j++)
                    {
                        if (i == 0 && j == 0) continue; // Skip the center plane

                        string adjacentName = (rowNumber + i).ToString() + (columnNumber + j).ToString();

                        if (childTransform.name.Contains(adjacentName))
                        {
                            Debug.Log("Adjacent plane:" + childTransform.name);
                            if (!childTransform.GetComponent<InfectOrCure>().isInfected && !childTransform.GetComponent<InfectOrCure>().isCured)
                            {
                                childTransform.GetComponent<InfectOrCure>().isInfected = true;
                            }
                        }
                    }

                }

            }


            else if (isHit)
             {
                if (childTransform.name.Contains((rowNumber + spread).ToString() + columnNumber.ToString()) ||
                   childTransform.name.Contains(rowNumber.ToString() + (columnNumber + spread).ToString()) ||
                   childTransform.name.Contains((rowNumber - spread).ToString() + columnNumber.ToString()) ||
                   childTransform.name.Contains(rowNumber.ToString() + (columnNumber - spread).ToString())
                   )
                {
                    if (!childTransform.GetComponent<InfectOrCure>().isCured)
                    {
                        childTransform.GetComponent<InfectOrCure>().isCured = true;
                        childTransform.GetComponent<InfectOrCure>().isInfected = false;
                        childTransform.GetComponent<InfectOrCure>().groundZero = false;
                    }
                }
             }
        }
    }
}
