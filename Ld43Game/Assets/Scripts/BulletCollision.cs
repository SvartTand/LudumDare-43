using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

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
            Destroy(gameObject);
        }
        
    }
}
