using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    [SerializeField] private float RATE_OF_FIRE;
    private GameObject player;
    private float cooldown;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float distanceToShoot;

    [SerializeField] private float BULLET_LIFETIME;
    [SerializeField] private float BULLET_SPEED;
    private float dist;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(transform.position, player.transform.position);
        transform.LookAt(player.transform);
        transform.Rotate(dist * -0.15f, 0, 0);
        cooldown -= Time.deltaTime;
        if (cooldown <= 0 && distanceToShoot >= dist)
        {
            cooldown = RATE_OF_FIRE;
            GameObject shot1 = (GameObject)GameObject.Instantiate(bullet, bulletSpawn.position, transform.rotation);
            
            shot1.GetComponent<Rigidbody>().AddForce(shot1.transform.forward * BULLET_SPEED);
            Destroy(shot1, BULLET_LIFETIME);
        }
	}
}
