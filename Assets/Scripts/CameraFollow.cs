﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        var targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}