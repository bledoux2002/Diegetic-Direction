using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using Application = UnityEngine.Application;
using Debug = UnityEngine.Debug;

public class Clock : MonoBehaviour
{
    public static string DataLogFile = "";

    [HideInInspector]
    //public string sceneName;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (DataLogFile.Length == 0) DataLogFile = Application.persistentDataPath + "/Log.txt";
        //sceneName = SceneManager.;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    /*
    void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Completed in " + timer.ToString() + " seconds.");
            string finalTime = sceneName + ": " + timer.ToString() + "\n";
            Log(finalTime);
        }
    }*/

    public void Log(string log)
    {
        // format -> date#log
        string output = "";
        output += DateTime.Now.ToString();
        output += ("\t" + log + "\n");

        //Debug.Log(Application.persistentDataPath);

        if (DataLogFile.Length == 0)
            DataLogFile = Application.persistentDataPath + "/DataLog.txt";
        

        // add to a local log file
        File.AppendAllText(DataLogFile, output);

    }
}
