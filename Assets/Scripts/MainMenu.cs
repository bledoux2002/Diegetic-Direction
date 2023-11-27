using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string scene;

    [HideInInspector]
    public static List<string> scenes = new List<string>();

    void Awake()
    {
        scenes.Add("Landmark");
        scenes.Add("Light");
        scenes.Add("Path");
        scenes.Add("Terrain");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
