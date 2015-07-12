using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    private const float WarpTimeToWin = 3f;

    public int Score = 0;

    private bool _isGameOver = false;
    private bool _isGameWin = false;
    private DateTime _endTime;
    private Text _scoreText;
    private Text _countdownText;
    private Text _gameWinText;
    private Text _gameLoseText;

    // Use this for initialization
	void Start () 
    {
	    _scoreText = GameObject.FindGameObjectWithTag("Score")
            .GetComponent<Text>();

        _countdownText = GameObject.FindGameObjectWithTag("Countdown")
            .GetComponent<Text>();

        _gameWinText = GameObject.FindGameObjectWithTag("GameWin")
            .GetComponent<Text>();

        _gameLoseText = GameObject.FindGameObjectWithTag("GameLose")
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

    public void SetJumpCountdown(float warpTime)
    {
        if (warpTime > WarpTimeToWin)
            SetGameWin();

        var warpTimeRemaining = WarpTimeToWin - warpTime;

        if (_isGameWin)
            _countdownText.text = "Jump to lightspeed complete.";

        else if (warpTime > 0f)
            _countdownText.text = "Jump to lightspeed in " + warpTimeRemaining.ToString("N2") + " seconds.";

        else 
            _countdownText.text = string.Empty;        
    }

    public void SetGameWin()
    {
        _gameWinText.enabled = true;

        _isGameOver = true;

        _isGameWin = true;

        _endTime = DateTime.Now;
    }

    public void SetGameOver()
    {
        _gameLoseText.enabled = true;

        _isGameOver = true;               

        _endTime = DateTime.Now;
    }
}
