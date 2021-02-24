﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBillboarder : MonoBehaviour
{
    [SerializeField]
    Vector3 cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam, Vector3.up);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
