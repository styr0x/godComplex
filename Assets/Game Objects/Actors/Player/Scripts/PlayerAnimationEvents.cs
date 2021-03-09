using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField]
    Animator theAnimator;
    [SerializeField]
    GameObject pistol;
    [SerializeField]
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void stopTakingDamage()
    {
        theAnimator.SetBool("takingDamage", false);
        Debug.Log("I Stopped Taking Damage!");
    }
    public void damageKnockBack()
    {

    }
    public void stayDead()
    {
        theAnimator.SetBool("isDying", false);
        theAnimator.SetBool("isDead", true);
    }
    public void callDoMuzzleFlash()
    {
        pistol.GetComponent<MuzzleFlash>().doMuzzleFlash();
    }

    public void callDoneReloading()
    {
        pistol.GetComponent<Pistol>().doneReloading();
    }

}
