using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableScript : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private float MaxHp;
    private float hp;
    [SerializeField] private float sacValue;

    [SerializeField] private GameObject explosion;


   void Start () {
        hp = MaxHp;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Detonate(100);

        }
    }

    public void Detonate(float dmg)
    {
        hp -= dmg;
        if(hp<= 0)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().Shake(0.2f, 0.5f, 1);
            GameObject.FindWithTag("Player").GetComponent<Health>().ChangeSac(sacValue);
            GameObject.FindWithTag("God").GetComponent<MeteorSpawningSystem>().AddTime(sacValue);
            GameObject o = (GameObject) GameObject.Instantiate(explosion);
            o.transform.position = transform.position;
            Destroy(o, 5);
            Destroy(gameObject);
        }
        
    }
}
