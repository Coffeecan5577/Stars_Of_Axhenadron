using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private int currentScore = 0;
    private Text scoreText;

	// Use this for initialization
	void Start ()
	{
	    scoreText = GetComponent<Text>();
	    scoreText.text = currentScore.ToString();
	}

    public void ScoreHit(int scoreIncrease)
    {
        currentScore += scoreIncrease;
        scoreText.text = currentScore.ToString();
    }
}
