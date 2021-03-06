﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpriteRotator : MonoBehaviour
{
    float enemyAngle, angleToCamera, angleToLookpoint;
    Vector3 lookPointDir, camDir;
    [Header("Components:")]
    [SerializeField]
    Transform cam;
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer theSpriteRenderer;
    [Header("Sprites:")]
    public Sprite front;
    public Sprite slightRight;
    public Sprite right;
    public Sprite slightBackRight;
    public Sprite back;
    public Sprite slightBackLeft;
    public Sprite Left;
    public Sprite slightLeft;
    [HideInInspector]
    public Transform lookPoint;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }
    // Update is called once per frame
    void Update()
    {
        //"Billboardar" spriten
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        //"Fryser" rotationen
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        //Enemyns xyz mot look pointen 
        if (lookPoint != null)
        {
            lookPointDir = transform.position - lookPoint.position;
        }
        //Enemyns xyz mot kameran
        camDir = transform.position - cam.position;
        //Grader till look point
        angleToLookpoint = Mathf.Atan2(lookPointDir.z, lookPointDir.x) * Mathf.Rad2Deg;
        //Grader till kameran
        angleToCamera = Mathf.Atan2(camDir.z, camDir.x) * Mathf.Rad2Deg;
        //Grader mellan look point och kameran
        enemyAngle = angleToCamera - angleToLookpoint;
        //Gör så att spriten normalt inte är spegelvänd
        theSpriteRenderer.flipX = false;
        //Resettar ti 0 grader
        if (enemyAngle < 0)
        {
            enemyAngle += 360;
        }
        //The sprite rotation itself
        if (enemyAngle >= 292.5f && enemyAngle < 337.5f)
        {
            theSpriteRenderer.sprite = slightLeft;
            
        }
        else if (enemyAngle >= 22.5f && enemyAngle < 67.5f)
        {
            theSpriteRenderer.sprite = slightRight;
            theSpriteRenderer.flipX = true;
        }
        else if (enemyAngle >= 67.5f && enemyAngle < 112.5f)
        {
            theSpriteRenderer.sprite = right;
            theSpriteRenderer.flipX = true;
        }
        else if (enemyAngle >= 112.5f && enemyAngle < 157.5f)
        {
            theSpriteRenderer.sprite = slightBackRight;
            theSpriteRenderer.flipX = true;
        }
        //Notera att de nästa 3 rotationerna är spegelvända
        else if (enemyAngle >= 157.5f && enemyAngle < 202.5f)
        {
            theSpriteRenderer.sprite = back;
        }
        else if (enemyAngle >= 202.5f && enemyAngle < 247.5f)
        {
            theSpriteRenderer.sprite = slightBackLeft;
            
        }
        else if (enemyAngle >= 247.5f && enemyAngle < 292.5f)
        {
            theSpriteRenderer.sprite = Left;
            
        }
        else if (enemyAngle >= 337.5f || enemyAngle < 22.5f)
        {
            theSpriteRenderer.sprite = front;
        }
        if (animator.GetBool("isChasing"))
        {
            theSpriteRenderer.sprite = front;
        }
    }
}
