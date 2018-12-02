using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGenerator : MonoBehaviour {

    [SerializeField] private GameObject bushType;
    [SerializeField] private GameObject palmType;
    [SerializeField] private float maxBushes;

    [SerializeField] private float maxX;
    [SerializeField] private float maxZ;

    [SerializeField] private float BushY;
    [SerializeField] private float PalmY;

    private float bushes = 0;

    // Use this for initialization
    void Start () {
        SpawnBushes();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnBushes()
    {
        while (bushes < maxBushes)
        {

            GameObject d = GameObject.Instantiate(bushType, new Vector3(Random.Range(-maxX, maxX), BushY, Random.Range(-maxZ, maxZ)), transform.rotation);
            GameObject p = GameObject.Instantiate(palmType, new Vector3(Random.Range(-maxX, maxX), PalmY, Random.Range(-maxZ, maxZ)), transform.rotation);
            bushes++;
        }
        bushes = 0;

    }
}
