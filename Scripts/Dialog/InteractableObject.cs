using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public PanelManager panelManager;
    public List<string> dialogs;

    // Start is called before the first frame update
    void Start()
    {
        panelManager = FindObjectOfType<PanelManager>();
    }

    void OnMouseDown()
    {
        panelManager.CallDialogPanel(dialogs);
    }
}
