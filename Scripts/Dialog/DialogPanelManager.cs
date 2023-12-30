using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPanelManager : MonoBehaviour
{
    public TextMeshProUGUI tmpUGUI;
    public List<string> dialogs;
    public int dialogNum;
    public float textSpeed;

    // Since we need the Dialog Panel to appear everytime it turn on, 
    // Oneable is used instead of on Start.
    void OnEnable()
    {
        tmpUGUI = GetComponentInChildren<TextMeshProUGUI>();
        dialogNum = 0;
        //tmpUGUI.text = dialogs[dialogNum++];
        StartCoroutine(TypeLine(dialogs[dialogNum++]));
    }
    
    void Update()
    {
        // The dialog panel update everytime player hit space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            
            if (dialogNum < dialogs.Count)
            {
                //tmpUGUI.text = dialogs[dialogNum++];
                StartCoroutine(TypeLine(dialogs[dialogNum++]));
            }
            else
            {
                dialogs.Clear();
                this.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator TypeLine(string dialog)
    {
        tmpUGUI.text = string.Empty;

        foreach(char c in dialog.ToCharArray())
        {
            tmpUGUI.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
