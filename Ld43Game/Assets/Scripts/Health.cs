﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public float maxHp;
    private float hp;
    [SerializeField] private Image hpBar;
    [SerializeField] private Text hpText;
    

    public float maxSacrifices;
    private float sacrifices;

	// Use this for initialization
	void Start () {
        hp = maxHp;
        sacrifices = maxSacrifices;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeHp(float dmg)
    {
        hp -= dmg;
        hpBar.fillAmount = hp / maxHp;
        hpText.text = hp + "/" + maxHp;

        if(hp <= 0)
        {
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
            Debug.Log("GAME_Over");
        }
    }

    public void ChangeSac(float sacrifice)
    {
        sacrifices -= sacrifice;
       
    }
}
