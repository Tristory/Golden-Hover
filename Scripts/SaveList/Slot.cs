using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour
{
    public string slotName;

    public void SlotSetting(string saveName)
    {
        slotName = saveName;
        GetComponentInChildren<TextMeshProUGUI>().text = saveName;
    }

    public void SetAsCurrentSave()
    {
        SaveListManager.currentSaveFolder = slotName;
        //Debug.Log(SaveListManager.currentSaveFolder);
    }
}
