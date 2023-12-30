using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    public void SaveScriptable()
    {
        if (SaveListManager.currentSaveFolder == null)
        {
            Debug.Log("No current save!");
            return;
        }

        string path = Path.Combine(Application.dataPath, "SaveSO", SaveListManager.currentSaveFolder);

        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(path + string.Format("/{0}.dat", i));
            //FileStream file = File.Create("Assets/SaveSO" + string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();

            var json = JsonUtility.ToJson(objects[i]);

            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptable()
    {
        if (SaveListManager.currentSaveFolder == null)
        {
            Debug.Log("No current save!");
            return;
        }

        string path = Path.Combine(Application.dataPath, "SaveSO", SaveListManager.currentSaveFolder);

        for (int i = 0; i < objects.Count; i++)
        {
            if(File.Exists(path + string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(path + string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                file.Close();
            }
            else
            {
                Debug.Log("No save exist!");
            }
        }
    }

    public void ResetScriptable()
    {
        if (SaveListManager.currentSaveFolder == null)
        {
            Debug.Log("No current save!");
            return;
        }

        string path = Path.Combine(Application.dataPath, "SaveSO", SaveListManager.currentSaveFolder);

        for(int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(path + string.Format("/{0}.dat", i)))
            {
                File.Exists(path + string.Format("/{0}.dat", i));
            }
        }
    }

    public bool MakeRepository(string saveName)
    {
        string path = Path.Combine(Application.dataPath, "SaveSO", saveName);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            return true;
        }
        else
        {
            return false;
        }
    }
}
