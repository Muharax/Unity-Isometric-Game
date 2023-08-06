using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;

public class CameraDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    public float dragSpeed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        // Ścieżka do pliku
        string path = "C:/Users/Neo/My project (2)/Assets/settings.txt";

        // Sprawdzenie, czy plik istnieje
        if (File.Exists(path))
        {
            // Odczytanie wszystkich linii z pliku
            string[] lines = File.ReadAllLines(path);

            // Parsowanie linii do zmiennych
            foreach (string line in lines)
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    string key = parts[0];
                    float value = float.Parse(parts[1]);

                    switch (key)
                    {
                        case "dragSpeed":
                            dragSpeed = value;
                            break;
                        case "minX":
                            minX = value;
                            break;
                        case "maxX":
                            maxX = value;
                            break;
                        case "minY":
                            minY = value;
                            break;
                        case "maxY":
                            maxY = value;
                            break;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Nie można odnaleźć pliku: " + path);
        }
    }

    void Update()
    {
         if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
            
            Vector3 newPos = transform.position + move;
            newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
            newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
            transform.position = newPos;

            dragOrigin = Input.mousePosition;
        }
    }
}











