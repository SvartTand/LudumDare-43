﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playButtonScript : MonoBehaviour {

	public void playPressed()
    {
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }
    
}
