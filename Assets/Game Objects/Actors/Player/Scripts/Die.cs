using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Animator theAnimator;

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        theAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deathRotation()
    {
        float singleStep = speed * Time.deltaTime;
        Vector3 randomDir = new Vector3(0, Random.Range(0f, 1f), 0);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, randomDir, singleStep, 0.0f);
        
    }

    public void stayDead()
    {
        theAnimator.SetBool("isDying", false);
        theAnimator.SetBool("isDead", true);
    }
}
