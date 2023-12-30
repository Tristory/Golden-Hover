using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveListManager : MonoBehaviour
{
    public static string currentSaveFolder;
    public GameObject Content;
    public GameObject button;
    public SaveManager saveManager;
    public List<string> SaveFolderNames;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GetComponent<SaveManager>();
        //MakeButton();
        GetAllFolderNames();
        MakeSavebuttons();
    }

    void MakeSavebuttons()
    {
        foreach (string name in SaveFolderNames)
        {
            MakeButton(name);
        }
    }

    void MakeButton(string buttonName)
    {
        GameObject newButton = Instantiate(button, Content.transform);
        newButton.GetComponent<Slot>().SlotSetting(buttonName);
    }

    void GetAllFolderNames()
    {
        //string path = Application.dataPath + "/TestFolder";
        string path = Path.Combine(Application.dataPath, "SaveSO");
        string[] folders = Directory.GetDirectories(path);

        foreach (string folder in folders)
        {
            SaveFolderNames.Add(Path.GetFileName(folder));
        }
    }

    public void MakeNewSave(string saveName)
    {
        if (saveManager.MakeRepository(saveName))
        {
            SaveFolderNames.Add(saveName);
            MakeButton(saveName);            
        }
        else
        {
            Debug.Log("Save already exist!");
        }
        
    }
}
