﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerDown : MonoBehaviour
{
    [SerializeField] private Transform previousLocation;
    [SerializeField] private Transform nextLocation;
    [SerializeField] private CameraPlayerFollower cam;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {

            if (collider.transform.position.y > transform.position.y)
            {
                cam.CameraMoveToY(nextLocation);
            }
            else
            {
                cam.CameraMoveToY(previousLocation);
            }


        }
    }
}
