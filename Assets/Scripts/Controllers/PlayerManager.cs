﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour {

	#region Singleton

	public static PlayerManager instance;

	private void Awake() {
		if(instance == null){
			instance = this;
		}
	}

	#endregion 

	public void KillPlayer(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
