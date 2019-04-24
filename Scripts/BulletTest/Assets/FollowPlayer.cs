using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    Transform playerTransform;

    [Range (1f, 10f)]
    public float speed = 5f;

    ///distance to stop before colliding or getting close to player
    [Range (3, 5)]
    public int stoppingDistance = 3;

    ///distance to get avay from player!
    [Range (0f, 2f)]
    public int retreatDistance = 1;

    public GameObject bullet;

    //delay before next shot
    public float fireDelay = 1f;
    private float tmpFireDelay; //variable to reset the fireDelay to its original value after beign 0
    // Start is called before the first frame update
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag ("Player")
            .GetComponent<Transform> ();
        tmpFireDelay = fireDelay;
    }
    private float distance2Player;
    // Update is called once per frame
    void Update () {

        //-------------Movement-------------//
        distance2Player = Vector2.Distance (transform.position, playerTransform.position);
        if (distance2Player > stoppingDistance) {
            transform.position = Vector2.MoveTowards (transform.position, playerTransform.position, speed * Time.deltaTime);
        } else if (distance2Player < retreatDistance) {

            transform.position = Vector2.MoveTowards (transform.position, playerTransform.position, -speed * Time.deltaTime);
        }
        //-------------Shooting-------------//
        if (tmpFireDelay < 0) { //delay passed - shoot

            Instantiate (bullet, transform.position, Quaternion.identity);
            tmpFireDelay = fireDelay;

        } else {
            tmpFireDelay -= Time.deltaTime;
        }

    }
}