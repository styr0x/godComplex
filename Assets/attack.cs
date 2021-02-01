using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Attack()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Gun");
        Animator playerAnimator = player.GetComponent<Animator>();
        int health = playerAnimator.GetInteger("health");

        playerAnimator.SetInteger("health", health - 10);
        Debug.Log(health);
    }
}
