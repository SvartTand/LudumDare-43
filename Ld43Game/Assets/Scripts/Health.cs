﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float maxHp;
    private float hp;
    [SerializeField] private Image hpBar;
    [SerializeField] private Text hpText;

	// Use this for initialization
	void Start () {
        hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeHp(float dmg)
    {
        hp -= dmg;
        hpBar.fillAmount = maxHp / hp;
        hpText.text = hp + "/" + maxHp;
    }
}