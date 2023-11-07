using System;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    [SerializeField] private GameObject target;

    [SerializeField] private float anglesPerSecond = 45;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, anglesPerSecond * Time.deltaTime);
    }
}