using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float knockBack = -10f;
    public float fireRate = 500f;
    public float nextTimeToFire = 0f;

    public Camera fpsCam;
    Animator enemyAnimator, playerAnimator;
    Rigidbody theRigidBody;



    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            shoot();
        }
    }

    void shoot()
    {
        playerAnimator = GetComponentInParent<Animator>();
        playerAnimator.SetBool("isShooting", true);

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


}
