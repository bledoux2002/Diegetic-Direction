using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string scene;

    private float timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = GameObject.Find("FirstPersonController").GetComponent<Clock>().timer;
            Debug.Log("Completed in " + timer.ToString() + " seconds.");
            SceneManager.LoadScene(scene);
        }
    }
}