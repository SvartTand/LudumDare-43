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
        RaycastHit[] hits;
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray,100);
        if(hits.Length == 0)
        {
            turret.LookAt(ray.GetPoint(50));
        }
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.collider.tag != "Player")
            {
                turret.LookAt(hit.point);
                i = hits.Length;
            }
               
        }
            

        //turret.rotation = Quaternion.RotateTowards(turret.rotation, rot.rotation, rotDelta);
        if(Input.GetMouseButton(0) && cooldown >= RATE_OF_FIRE)
        {
            cooldown = 0;
            cam.GetComponent<CameraController>().Shake(0.2f, 0.2f, 1);
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
