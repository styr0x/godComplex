using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    float knockBack = 100;
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Animator playerAnimator = player.GetComponent<Animator>();
        CharacterController playerBody = player.GetComponent<CharacterController>();
        int health = playerAnimator.GetInteger("health");

        playerAnimator.SetInteger("health", health - 10);
        playerAnimator.SetBool("takingDamage", true);
        Debug.Log(health);
    }
}
