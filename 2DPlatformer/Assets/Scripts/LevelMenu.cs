using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
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
        GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 200), "Выбор уровня: ");
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 25, 25), "1"))
            {
                Application.LoadLevel("level1");
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 100, 25, 25), "2"))
            {
                Application.LoadLevel("level2");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 25, 25), "3"))
            {
                Application.LoadLevel("level3");
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 - 50, 25, 25), "4"))
            {
                Application.LoadLevel("level4");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 25, 25), "5"))
            {
                Application.LoadLevel("level5");
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 50, 25), "Назад"))
            {
                Application.LoadLevel("Menu");
            }
        }
    }
}
