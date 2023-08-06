using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    public GameObject buildMenu; // Przypisz w inspektorze

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Debug.Log("OnMouseDown called."); // Ta linia powinna pojawić się w konsoli po kliknięciu na budynek.
        buildMenu.SetActive(true);
    }
}
