﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour {

    private Transform player;

    [SerializeField] private float MaxHp;
    private float hp;
    [SerializeField] private float sacValue;

    [SerializeField] private GameObject explosion;
    private GameObject god;

    // Use this for initialization
    void Start () {
        hp = MaxHp;
        god = GameObject.FindGameObjectWithTag("God");
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player);
	}

    public void Detonate(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().Shake(0.2f, 0.5f, 1);
            GameObject.FindWithTag("Player").GetComponent<Health>().ChangeSac(sacValue);
            god.GetComponent<MeteorSpawningSystem>().AddTime(sacValue);
            god.GetComponent<DudeSpawnerSystem>().removeDude();
            GameObject o = (GameObject)GameObject.Instantiate(explosion);
            o.transform.position = transform.position;
            Destroy(o, 5);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        Detonate(1);


    }

}
