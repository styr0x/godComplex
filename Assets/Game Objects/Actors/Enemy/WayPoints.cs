using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public List<GameObject> wayPoints;
    public GameObject currentWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("WayPoint"));
        currentWayPoint = wayPoints[Random.Range(0, 4)];
        Debug.Log(currentWayPoint);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
