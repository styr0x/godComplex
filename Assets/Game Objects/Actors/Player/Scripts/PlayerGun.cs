using UnityEngine;
using TMPro;

public class PlayerGun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float knockBack = -10f;
    public float fireRate = 500f;
    float nextTimeToFire = 0f;

    int ammoInClip, totalAmmo, clipCapacity;
    bool canReload;

    public Camera fpsCam;
    Animator enemyAnimator, playerAnimator;
    Rigidbody theRigidBody;
    TextMeshProUGUI ammoUi;


    void Start()
    {
        ammoUi = GameObject.FindGameObjectWithTag("Ammo").GetComponent<TextMeshProUGUI>();
        playerAnimator = GetComponentInParent<Animator>();
        clipCapacity = 7;
        ammoInClip = playerAnimator.GetInteger("ammoInClip");
        totalAmmo = playerAnimator.GetInteger("totalAmmo");
        canReload = true;
    }
    // Update is called once per frame
    void Update()
    {
        ammoUi.SetText(ammoInClip + "/" + totalAmmo);

        if (Input.GetButtonDown("Fire1") && Time.time > nextTimeToFire && ammoInClip > 0)
        {
            nextTimeToFire = Time.time + fireRate;
            shoot();
        }

        if (Input.GetButton("Reload") && totalAmmo > 0 && canReload == true && ammoInClip < 7)
        {
            canReload = false;
            reload();
        }
    }

    void shoot()
    {
        ammoInClip -= 1;
        playerAnimator.SetBool("isShooting", true);
        Debug.Log("Ammo in clip: " + ammoInClip);

        RaycastHit hit;
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward);


        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
            {
                enemyAnimator = hit.collider.GetComponent<Animator>();
                theRigidBody = hit.collider.GetComponent<Rigidbody>();

                enemyAnimator.SetBool("takingDamage", true);
                enemyAnimator.SetInteger("health", enemyAnimator.GetInteger("health") - 1);
                theRigidBody.AddForce(fpsCam.transform.forward * knockBack);

                Debug.Log(hit.collider.gameObject.GetComponent<Animator>().GetInteger("health"));
            }
        }
    }

    void reload()
    {
        playerAnimator.SetBool("isReloading", true);   
    }

    public void doneReloading()
    {
        totalAmmo -= clipCapacity - ammoInClip;
        ammoInClip = clipCapacity;
        playerAnimator.SetBool("isReloading", false);
        canReload = true;
        Debug.Log("Total ammo: " + totalAmmo);
        Debug.Log("Reloaded, total clip ammo is now: " + ammoInClip);
    }


}
