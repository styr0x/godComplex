using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public float flashTime = 0f;
    GameObject muzzleFlashPrefab, muzzleFlashSpritePrefab, theFlash, theFlashSprite;
    GameObject player, canvas;
    // Start is called before the first frame update
    void Start()
    {
        muzzleFlashPrefab = Resources.Load<GameObject>("MuzzleFlash") as GameObject;
        muzzleFlashSpritePrefab = Resources.Load<GameObject>("MuzzleFlashSprite") as GameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doMuzzleFlash()
    {
        theFlash = Instantiate(muzzleFlashPrefab, player.transform);
        theFlashSprite = Instantiate(muzzleFlashSpritePrefab, canvas.transform);
        theFlashSprite.transform.SetParent(canvas.transform);
        theFlashSprite.transform.SetAsFirstSibling();
        theFlashSprite.transform.Rotate(0, 0, Random.Range(-30f, 30f));
        theFlash.transform.SetParent(player.transform);
        Destroy(theFlashSprite, flashTime);
        Destroy(theFlash, flashTime);
    }
}
