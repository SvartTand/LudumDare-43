using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    [SerializeField] private float maxHp;
    private float hp;
    public EnemySpawnerSystem spawnerSystem;
    public bool turret = false;

    public GameObject explosion;
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
            Debug.Log(spawnerSystem);
            try{
                if (turret)
                {
                    spawnerSystem.KillTurret();
                }
                else
                {
                    spawnerSystem.KillEnemy();
                }
                
            }
            catch { }
            GameObject o = (GameObject)GameObject.Instantiate(explosion);
            o.transform.position = transform.position;
            GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().Shake(0.2f, 0.5f, 1);
            Destroy(o, 5);
            Destroy(gameObject);
        }
        
    }
}
