using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveData/Test")]
public class SaveData : ScriptableObject
{
    public int testInt;
    public List<string> testList;
}
