using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerHit = 12;

    private int currentScore = 0;
    private Text scoreText;

	// Use this for initialization
	void Start ()
	{
	    scoreText = GetComponent<Text>();
	    scoreText.text = currentScore.ToString();
	}

    public void ScoreHit()
    {
        currentScore += scorePerHit;
        scoreText.text = currentScore.ToString();
    }
}
