using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField]
    GameObject player, pistol;
    [SerializeField]
    GameObject muzzleFlashPrefab, muzzleFlashSpritePrefab;
    public float flashTime = 0f;
    GameObject theFlash, theFlashSprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doMuzzleFlash()
    {
        theFlash = Instantiate(muzzleFlashPrefab, player.transform);
        theFlashSprite = Instantiate(muzzleFlashSpritePrefab, pistol.transform);
        theFlashSprite.transform.SetParent(pistol.transform);
        theFlashSprite.transform.SetAsFirstSibling();
        theFlashSprite.transform.Rotate(0, 0, Random.Range(-30f, 30f));
        theFlash.transform.SetParent(player.transform);
        Destroy(theFlashSprite, flashTime);
        Destroy(theFlash, flashTime);
    }
}
