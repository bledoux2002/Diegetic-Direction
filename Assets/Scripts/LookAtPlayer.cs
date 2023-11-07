using System;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;

    void Awake()
    {
        player = GameObject.FindWithTag("MainCamera").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
        }
    }
}