using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    float knockBack = 100;
    GameObject healthBar;
    Slider healthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        healthBarSlider = healthBar.GetComponent<Slider>();
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
        healthBarSlider.value = playerAnimator.GetInteger("health");
        playerAnimator.SetBool("takingDamage", true);
        Debug.Log(health);
    }
}
