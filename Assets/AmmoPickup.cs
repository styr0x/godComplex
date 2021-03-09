using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    GameObject player;
    Pistol pistol;
    Animator playerAnimator;
    float distance;
    int totalAmmo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pistol = player.GetComponent<Pistol>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        
        if (distance < 1.5)
        {
            pistol.totalAmmo += 21;
            Destroy(gameObject);
        }
    }
}
