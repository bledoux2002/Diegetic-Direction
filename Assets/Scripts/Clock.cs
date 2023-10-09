using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

    [HideInInspector]
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Completed in " + timer.ToString() + " seconds.");
        }
    }
}
