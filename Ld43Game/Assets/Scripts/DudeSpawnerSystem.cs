using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeSpawnerSystem : MonoBehaviour {

    [SerializeField] private GameObject[] dudeTypes;
    [SerializeField] private float maxDudes;

    [SerializeField] private AudioClip[] audioComments;
    [SerializeField] private AudioSource source;

    [SerializeField] private float maxX;
    [SerializeField] private float maxZ;

    [SerializeField] private float Y;

    private float dudes = 0;

    // Use this for initialization
    void Start () {
        SpawnDudes();
	}
	
	// Update is called once per frame
	void Update () {
        SpawnDudes();
	}

    private void SpawnDudes()
    {
        while (dudes < maxDudes)
        {
            
            GameObject d = GameObject.Instantiate(dudeTypes[(int) Random.Range(0, dudeTypes.Length-1)], new Vector3(Random.Range(-maxX, maxX), Y, Random.Range(-maxZ, maxZ)), transform.rotation);
            dudes++;
        }
    }

    public void removeDude()
    {
        
        if(Random.value <= 0.3f)
        {
            if (!source.isPlaying)
            {
                int r = Random.Range(0, audioComments.Length);
                source.clip = audioComments[r];
                source.Play();
            }
            


        }
        dudes--;
    }
}
