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
    private Text _gameWinText;
    private Text _gameLoseText;

    // Use this for initialization
	void Start () 
    {
	    _scoreText = GameObject.FindGameObjectWithTag("Score")
            .GetComponent<Text>();

        var gameWin = GameObject.FindGameObjectWithTag("GameWin")
            .GetComponent<Text>();

        _gameWinText = gameWin.GetComponent<Text>();

        var gameOver = GameObject.FindGameObjectWithTag("GameLose")
            .GetComponent<Text>();

        _gameLoseText = gameOver.GetComponent<Text>();
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

    public void SetGameWin()
    {
        _gameWinText.enabled = true;

        _isGameOver = true;

        _endTime = DateTime.Now;
    }

    public void SetGameOver()
    {
        _gameLoseText.enabled = true;

        _isGameOver = true;

        _endTime = DateTime.Now;
    }
}
