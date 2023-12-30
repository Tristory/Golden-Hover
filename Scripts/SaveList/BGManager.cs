using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public List<GameObject> childrenObjects;
    public int turnN;

    void Start()
    {
        turnN = 0;
        GetAllChildren();
        ChildObjectSet();
    }

    void GetAllChildren()
    {
        foreach (Transform child in this.transform)
        {
            childrenObjects.Add(child.gameObject);
        }
    }

    void ChildObjectSet()
    {
        childrenObjects[turnN].SetActive(true);
    }

    public void NextChildObject()
    {
        childrenObjects[turnN++].SetActive(false);

        if (turnN < childrenObjects.Count)
        {
            ChildObjectSet();
        }
        else
        {
            turnN = 0;
            ChildObjectSet();
        }
    }

    public void PreviousChildObject()
    {
        childrenObjects[turnN--].SetActive(false);

        if (turnN >= 0)
        {
            ChildObjectSet();
        }
        else
        {
            turnN = childrenObjects.Count - 1;
            ChildObjectSet();
        }
    }
}
