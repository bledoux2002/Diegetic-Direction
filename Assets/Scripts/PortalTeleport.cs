using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

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
            timer = player.GetComponent<Clock>().timer;
            sceneName = SceneManager.GetActiveScene().name;
            Debug.Log("Completed in " + timer.ToString() + " seconds.");
            player.GetComponent<Clock>().Log(sceneName + ": " + timer + "\n");
            SceneManager.LoadScene(scene);
        }
    }
}