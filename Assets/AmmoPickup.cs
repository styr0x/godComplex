using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    GameObject player;
    Pistol pistol;
    M4 m4;
    Animator playerAnimator;
    float distance;
    int totalAmmo;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pistol = player.GetComponentInChildren<Pistol>();
        m4 = player.GetComponentInChildren<M4>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        
        if (distance < 1.5)
        {
            try
            {
                m4.totalAmmo += 30;
                
            }
            catch
            {
                pistol.totalAmmo += 21;
            }
            
            Destroy(gameObject);
        }
    }
}
