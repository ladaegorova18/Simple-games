using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 300), "Меню");
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 25), "Играть"))
        {
            Application.LoadLevel("level1");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 25), "Уровень"))
        {
            Application.LoadLevel("LevelMenu");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 25), "Выход"))
        {
            Application.Quit();
        }
    }
}
