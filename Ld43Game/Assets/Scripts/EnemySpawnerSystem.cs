using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerSystem : MonoBehaviour {

    [SerializeField] private GameObject flyingEnemy;
    [SerializeField] private float maxEnemies;

    [SerializeField] private GameObject turret;
    [SerializeField] private float maxTurrets;

    private float turretAmount = 0;
    private float enemyAmount = 0;
    private float cooldown = 0;


    [SerializeField] private float turretY;
    [SerializeField] private float MIN_TIME;
    [SerializeField] private Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
		if(cooldown >= MIN_TIME && enemyAmount <= maxEnemies * 0.5f)
        {
            Debug.Log("Spawning");
            while (enemyAmount < maxEnemies)
            {
                
                GameObject d = GameObject.Instantiate(flyingEnemy, spawnPoints[(int) Random.Range(0, spawnPoints.Length)]);
                d.GetComponent<FlyingEnemy>().targetWhenNotChasing = transform;
                d.GetComponent<Damage>().spawnerSystem = this;
                enemyAmount++;
            }
            cooldown = 0;
        }
        //Debug.Log(turretAmount);
        if(turretAmount <= maxTurrets * 0.5)
        {
            while (turretAmount < maxEnemies)
            {

                GameObject t = GameObject.Instantiate(turret, new Vector3(Random.Range(-140,140), turretY, Random.Range(-140,140)), transform.rotation);
                t.GetComponent<Damage>().spawnerSystem = this;
                t.GetComponent<Damage>().turret = true;
                turretAmount++;
            }
        }
        cooldown++;
	}

    public void KillEnemy()
    {
        enemyAmount--;
    }
    public void KillTurret()
    {
        turretAmount--;
    }
}
