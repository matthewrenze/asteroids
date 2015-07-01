using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public int Score = 0;
    private bool _isGameOver = false;
    private DateTime _endTime;

    private Text _scoreText;

    // Use this for initialization
	void Start () 
    {
	    _scoreText = GameObject.FindGameObjectWithTag("Score")
            .GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        _scoreText.text = "Score: " + Score;

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

	    if (!_isGameOver)
            return;

        if (DateTime.Now.Subtract(_endTime).Seconds < 2)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel("Main Scene");
	}

    public void AddToScore(int points)
    {
        Score += points;
    }

    public void SetGameOver()
    {
        _isGameOver = true;

        _endTime = DateTime.Now;
    }
}
