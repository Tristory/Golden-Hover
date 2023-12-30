using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public DialogPanelManager dialogPanelManager;
    //public List<string> dialogs;

    // Start is called before the first frame update
    void Start()
    {
        //dialogPanelManager = GetComponentInChildren<DialogPanelManager>();
        //CallDialogPanel(dialogs);
    }

    public void CallDialogPanel(List<string> dialogs)
    {
        dialogPanelManager.dialogs = dialogs.ToList();
        dialogPanelManager.gameObject.SetActive(true);
    }
}
