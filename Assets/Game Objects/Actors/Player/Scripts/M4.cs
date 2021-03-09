using UnityEngine;
using TMPro;
public class M4 : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ammoUi;
    [SerializeField]
    Camera fpsCam;
    public int ammoInClip, totalAmmo, clipCapacity;
    public float damage = 10f;
    public float range = 100f;
    public float knockBack = -10f;
    public float fireRate = 500f;
    float nextTimeToFire = 0f;
    bool canReload;
    Animator enemyAnimator, playerAnimator;
    Rigidbody theRigidBody;
    void Start()
    {
        playerAnimator = GetComponentInParent<Animator>();
        clipCapacity = 30;
        ammoInClip = 30;
        totalAmmo = 100;
        canReload = true;
    }
    // Update is called once per frame
    void Update()
    {
        ammoUi.SetText(ammoInClip + "/" + totalAmmo);
        if (Input.GetButton("Fire1") && ammoInClip > 0)
        {
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + fireRate;
                shoot();
            }

        }
        if (Input.GetButton("Reload") && totalAmmo > 0 && canReload == true && ammoInClip < 30)
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
