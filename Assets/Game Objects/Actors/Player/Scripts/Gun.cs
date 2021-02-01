using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float knockBack = -10f;

    public Camera fpsCam;
    Animator theAnimator;
    Rigidbody theRigidBody;



    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        RaycastHit hit;


        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
            {
                theAnimator = hit.collider.GetComponent<Animator>();
                theRigidBody = hit.collider.GetComponent<Rigidbody>();

                theAnimator.SetBool("takingDamage", true);
                theAnimator.SetInteger("health", theAnimator.GetInteger("health") - 1);
                theRigidBody.AddForce(fpsCam.transform.forward * knockBack);
                Debug.Log(hit.collider.gameObject.GetComponent<Animator>().GetInteger("health"));
            }
        }
    }
}
