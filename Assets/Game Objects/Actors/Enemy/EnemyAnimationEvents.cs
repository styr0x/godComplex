using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyAnimationEvents : MonoBehaviour
{
    [SerializeField]
    float ammoBoxForce, knockBack;
    [SerializeField]
    GameObject ammoBoxPrefab;
    GameObject player;
    Animator playerAnimator;
    CharacterController playerBody;
    
    GameObject healthBar, ammoBox;
    Slider healthBarSlider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        playerBody = player.GetComponent<CharacterController>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        healthBarSlider = healthBar.GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        knockBackPlayer();
    }

    private void knockBackPlayer()
    {
        if (playerAnimator.GetBool("takingDamage"))
        {
            playerBody.Move(knockBack * transform.forward * Time.deltaTime);
        }
    }
    public void Attack()
    {
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
        ammoBox = Instantiate(ammoBoxPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        ammoBox.GetComponent<Rigidbody>().AddForce(transform.forward * ammoBoxForce);

    }
}
