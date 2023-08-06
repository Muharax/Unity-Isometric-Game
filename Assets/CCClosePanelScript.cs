using UnityEngine;

public class CCClosePanelScript : MonoBehaviour
{
    public GameObject panelToClose; // przypisz w inspektorze

    public void ClosePanel()
    {
        Debug.Log("Closing panel");
        panelToClose.SetActive(false);
    }
}
