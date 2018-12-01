using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour {

    public GameObject explosion; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().ChangeHp(1);
        }
        GameObject o = (GameObject)GameObject.Instantiate(explosion);
        o.transform.position = collision.contacts[0].point;
        //o.transform.position.Set(o.transform.position.x, 0, o.transform.position.y);
        Destroy(o, 2);
        Destroy(gameObject);


    }
}
