using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    private const float WarpTimeToWin = 3f;

    public int Score = 0;

    private bool _isGameStarted = false;
    private bool _isGameOver = false;
    private bool _isGameWin = false;
    private GameObject _startMenu;
    private Text _copyright;
    private Text _scoreText;
    private Text _countdownText;
    private Text _gameWinText;
    private Text _gameLoseText;
    private GameObject _credits;
    private DateTime _endTime;
    private ShipMovement _shipMovement;
    private ShipFireWeapon _shipFireWeapon;
    private CameraChase _cameraChase;

    // Use this for initialization
	void Start ()
	{
        if (Input.GetKey(KeyCode.Alpha1))
            Application.LoadLevel("Level 1");

	    _startMenu = GameObject.FindGameObjectWithTag("StartMenu");

        _copyright = GameObject.FindGameObjectWithTag("Copyright")
            .GetComponent<Text>();

	    _scoreText = GameObject.FindGameObjectWithTag("Score")
            .GetComponent<Text>();

        _countdownText = GameObject.FindGameObjectWithTag("Countdown")
            .GetComponent<Text>();

        _gameWinText = GameObject.FindGameObjectWithTag("GameWin")
            .GetComponent<Text>();

        _gameLoseText = GameObject.FindGameObjectWithTag("GameLose")
            .GetComponent<Text>();

        _credits = GameObject.FindGameObjectWithTag("Credits");

        _credits.SetActive(false);

	    var ship = GameObject.FindGameObjectWithTag("Player");

	    _shipMovement = ship.GetComponentInChildren<ShipMovement>();

	    _shipFireWeapon = ship.GetComponentInChildren<ShipFireWeapon>();

	    var camera = GameObject.FindGameObjectWithTag("MainCamera");

	    _cameraChase = camera.GetComponentInChildren<CameraChase>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    HandleStartGame();

	    HandleMovement();

	    HandleFireWeapons();

	    HandleViewChange();

        _scoreText.text = "Score: " + Score;

	    HandleExitGame();

	    HandleResetLevel();

	    HandleShowCredits();
    }

    private void HandleStartGame()
    {
        if (!_isGameStarted && Input.anyKeyDown)
        {
            _startMenu.SetActive(false);

            _copyright.enabled = false;

            _isGameStarted = true;
        }
    }

    private void HandleMovement()
    {
        if (_shipMovement == null)
            return;

        if (Input.GetKey(KeyCode.LeftArrow))
            _shipMovement.RotateLeft();

        else if (Input.GetKey(KeyCode.RightArrow))
            _shipMovement.RotateRight();

        if (Input.GetKey(KeyCode.UpArrow)
            && Input.GetKey(KeyCode.LeftControl)
            && _shipMovement.HasWarp)
            _shipMovement.Warp();

        else if (Input.GetKey(KeyCode.UpArrow))
            _shipMovement.MoveForward();

        else if (Input.GetKey(KeyCode.DownArrow))
            _shipMovement.MoveBackward();

        else
            _shipMovement.Decelerate();

        if (!Input.GetKey(KeyCode.UpArrow)
            || !Input.GetKey(KeyCode.LeftControl))
            _shipMovement.DeWarp();
    }

    private void HandleFireWeapons()
    {
        if (_shipFireWeapon == null)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            _shipFireWeapon.FirePrimaryWeapon();
    }

    private void HandleViewChange()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            _cameraChase.IncreaseView();

        if (Input.GetKeyDown(KeyCode.RightAlt))
            _cameraChase.DecreaseView();            
    }

    private void HandleResetLevel()
    {
        if (!_isGameOver)
            return;

        if (DateTime.Now.Subtract(_endTime).Seconds < 2)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel("Main Scene");
    }

    private static void HandleExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void HandleShowCredits()
    {
        if (!_isGameOver || !_isGameWin)
            return;

        if (DateTime.Now.Subtract(_endTime).Seconds < 5)
            return;

        _gameWinText.enabled = false;

        _countdownText.enabled = false;

        _credits.SetActive(true);

        _copyright.enabled = true;
    }

    public void AddToScore(int points)
    {
        Score += points;
    }

    public void SetJumpCountdown(float warpTime)
    {
        if (_isGameWin)
            return;

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
