using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField]
    GameObject pistolParent, rifleParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("Hey 1");
            pistolParent.SetActive(true);
            rifleParent.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            Debug.Log("Hey 2");
            pistolParent.SetActive(false);
            rifleParent.SetActive(true);
        }
    }
}
