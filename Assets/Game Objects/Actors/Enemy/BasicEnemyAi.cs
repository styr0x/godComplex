using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAi : MonoBehaviour
{
    public float speed, discDistance, atkDistance;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        chase();
    }

    private void chase()
    {
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) <= discDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Vector3.Distance (transform.position, player.transform.position) <= atkDistance)
        {
            attack();
        }
    }

    private void attack()
    {

    }
}
