using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyAnimationEvents : MonoBehaviour
{
    [SerializeField]
    GameObject ammoBox;
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
    public void HasSpawned()
    {
        Animator theAnimator = GetComponent<Animator>();
        theAnimator.SetBool("hasSpawned", true);
    }
    public void spawnAmmoBox()
    {
        Instantiate(ammoBox, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
