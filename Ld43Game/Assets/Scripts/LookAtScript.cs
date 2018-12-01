using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour {

    private Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
