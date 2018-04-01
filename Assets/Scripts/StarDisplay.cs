using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private int stars = 0;
    private Text starText;

	// Use this for initialization
	private void Start () {
        try
        {
            starText = this.GetComponent<Text>();
        }
        catch
        {
            Debug.LogError("No Text element found on " + name);
        }

        starText.text = stars.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void UseStars(int amount)
    {
        stars -= amount;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
}
