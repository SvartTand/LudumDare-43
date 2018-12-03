using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreScript : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score: " + EnemySpawnerSystem.score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
