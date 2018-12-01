using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableScript : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private float MaxHp;
    private float hp;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hp = MaxHp;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerCollider")
        {
            Detonate(100);

        }
    }

    public void Detonate(float dmg)
    {
        hp -= dmg;
        if(hp<= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
