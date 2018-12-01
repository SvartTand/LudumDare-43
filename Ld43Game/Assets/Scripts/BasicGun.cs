using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour {

    [SerializeField] private Transform turret;
    [SerializeField] private float rotDelta;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;

    [SerializeField] private float RATE_OF_FIRE;
    [SerializeField] private float BULLET_SPEED;
    [SerializeField] private float BULLET_LIFETIME;
    private float cooldown = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Transform rot = turret;
        cooldown += Time.deltaTime;
        RaycastHit hit;
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag != "Player")
                turret.LookAt(hit.point);
        }
            

        //turret.rotation = Quaternion.RotateTowards(turret.rotation, rot.rotation, rotDelta);
        if(Input.GetMouseButtonDown(0) && cooldown >= RATE_OF_FIRE)
        {
            cooldown = 0;
            Shoot();
        }

	}

    private void Shoot()
    {
        GameObject shot1 = (GameObject)GameObject.Instantiate(bullet, bulletSpawn.position, turret.rotation);

        shot1.GetComponent<Rigidbody>().AddForce(shot1.transform.forward * BULLET_SPEED);
        Destroy(shot1, BULLET_LIFETIME);
    }


}
