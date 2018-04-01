using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (!levelManager)
		{
			Debug.LogError(this.name + ": Cannot find LevelManager");
		}
	}

	private void OnTriggerEnter2D()
	{
		levelManager.LoadLevel("Lose");
	}
}
