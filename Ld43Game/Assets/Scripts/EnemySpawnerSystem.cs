using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerSystem : MonoBehaviour {

    [SerializeField] private GameObject flyingEnemy;
    [SerializeField] private float maxEnemies;

    private float enemyAmount = 0;
    private float cooldown = 0;

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
                d.GetComponent<FlyingEnemy>().spawnerSystem = this;
                enemyAmount++;
            }
            cooldown = 0;
        }
        cooldown++;
	}

    public void KillEnemy()
    {
        enemyAmount--;
    }
}
