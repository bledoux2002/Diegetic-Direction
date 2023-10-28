using System;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;

    void Awake()
    {
        player = GameObject.Find("FirstPersonController").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
        }
    }
}