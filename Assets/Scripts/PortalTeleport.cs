using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = System.Random;

public class PortalTeleport : MonoBehaviour
{
    public string scene;

    //variables from clock
    private GameObject player;
    private float timer;
    private string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = GameObject.FindWithTag("Player");
            if (scene != "null")
            {
                timer = player.GetComponent<Clock>().timer;
                sceneName = SceneManager.GetActiveScene().name;
                Debug.Log("Completed in " + timer.ToString() + " seconds.");
                player.GetComponent<Clock>().Log(sceneName + ": " + timer + "\n");
                SceneManager.LoadScene(scene);
            } else if (MainMenu.scenes.Count == 0)
            {
                SceneManager.LoadScene("Finish");
            } else
            {
                Random rand = new Random();
                int index = rand.Next(MainMenu.scenes.Count);
                string sceneTemp = MainMenu.scenes[index];
                MainMenu.scenes.RemoveAt(index);
                Debug.Log(MainMenu.scenes.Count);
                Debug.Log("Loading scene; " + sceneTemp);
                SceneManager.LoadScene(sceneTemp);
            }
        }
    }
}