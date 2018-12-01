using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

    public GameObject explosion;

    //public float dmg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerCollider")
        {

        }
        else
        {
            if(collision.gameObject.tag == "Destructable")
            {
                collision.gameObject.GetComponent<DestructableScript>().Detonate(1);
            }
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<FlyingEnemy>().Damage(1);
            }

            GameObject o = (GameObject)GameObject.Instantiate(explosion);
            o.transform.position = transform.position;
            Destroy(o, 1.5f);
            Destroy(gameObject);
        }
        
    }
}
