using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status { SUCCESS, FAILURE };

	private int stars = 100;
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

    public Status UseStars(int amount)
    {
		if (stars >= amount)
		{
			stars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
        
		return Status.FAILURE; // Failure
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
}
