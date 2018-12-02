using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    [SerializeField] private float maxHp;
    private float hp;
	// Use this for initialization
	void Start () {
        hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Dmg(float dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
