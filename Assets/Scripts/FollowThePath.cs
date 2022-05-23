using UnityEngine;
using System;
using System.Collections.Generic;
using DG.Tweening;
public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;
    public bool moveCompleted = false;

    // Use this for initialization
    private void Start () {
        //Debug.Log("waypointIndex " + waypointIndex);
       
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {
        if (moveAllowed)
        {
            moveCompleted = false;
            Move();
        }
     
        
	}
    private Sequence _jumpSequence;
    private void Move()
    {

        if (waypointIndex <= waypoints.Length - 1)
        {
          
             transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;

            }
            
        }
    }
}
