using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private LevelManager levelManager;

	public Slider timerSlider;
	public Text timerText;
	private GameObject passedText;
	[Tooltip("Max Level time in sec.")]
	public float maxTime;
	private float currentTime;
	private bool bLevelFinished = false;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (!levelManager)
		{
			Debug.LogError(this.name + ": Cannot find LevelManager");
		}

		passedText = GameObject.Find("PassedText");
		if (!passedText)
		{
			Debug.LogWarning(this.name + ": Cannot find PassedText");
		}

		passedText.SetActive(false);

		currentTime = maxTime;
		timerSlider.maxValue = maxTime;
		timerSlider.value = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(timerSlider.value > 0)
		{
			Countdown();

			timerSlider.value -= Time.deltaTime;
			timerText.text = string.Format("{0:0}", currentTime);
		}
		else if(!bLevelFinished)
		{
			Debug.Log("Level passed!");
			passedText.SetActive(true);
			Invoke("LoadNextLevel", 2f);
			bLevelFinished = true;
		}
		
	}

	void Countdown()
	{
		currentTime -= Time.deltaTime;
	}

	void LoadNextLevel()
	{
		levelManager.LoadNextLevel();
	}
}
