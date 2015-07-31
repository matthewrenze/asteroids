using System;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    public float AccelerationRate = 0.25f;
    public float RotationSpeed = 100f;
    public float WarpSpeed = 1000f;
    public float MaxImpulseSpeed = 10f;
    public bool HasWarp = false;
    
    private GameController _controller;
    private GameObject _mainAudio;
    private AudioSource _warpAudio;
    public float _speed = 0.0f;
    private float _warpTime = 0;
    private bool _isWarping = false;
    
    void Start () 
    {
        _controller = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        _mainAudio = GameObject.FindGameObjectWithTag("MainAudio");

        var warpSound = Resources.Load<AudioClip>("Sounds/warp");

        _warpAudio = _mainAudio.AddComponent<AudioSource>();

        _warpAudio.clip = warpSound;
    }
	
	void Update () 
    {
	    HandleMovement();

	    HandleRotation();
        
	    CreateImpulseBubbles();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow)
            && Input.GetKey(KeyCode.LeftControl)
            && HasWarp)
            Warp();

        else if (Input.GetKey(KeyCode.UpArrow))
            MoveForward();

        else if (Input.GetKey(KeyCode.DownArrow))
            MoveBackward();

        else
            Decelerate();

        gameObject.transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (!Input.GetKey(KeyCode.UpArrow)
            || !Input.GetKey(KeyCode.LeftControl))
            DeWarp();
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            RotateLeft();

        else if (Input.GetKey(KeyCode.RightArrow))
            RotateRight();
    }

    private void Warp()
    {
        if (_warpTime >= 3.0)
            _speed = WarpSpeed;
        else if (_speed < WarpSpeed)
            _speed += AccelerationRate;
        
        if (_warpTime < 3.0f)
            Stretch();
        else
            Shrink();

        _warpTime += Time.deltaTime;

        _controller.SetJumpCountdown(_warpTime);

        if (!_isWarping)
        {
            _warpAudio.Play();

            _isWarping = true;
        }
    }

    private void MoveForward()
    {
        if (_speed > MaxImpulseSpeed && !_isWarping)
            _speed -= AccelerationRate * 5;
        else        
            _speed += AccelerationRate;        
    }

    private void MoveBackward()
    {
        if (_speed > MaxImpulseSpeed && !_isWarping)
            _speed -= AccelerationRate * 5;
        if (_speed > -MaxImpulseSpeed)
            _speed -= AccelerationRate;
    }

    private void Decelerate()
    {
        if (_speed > MaxImpulseSpeed)
            _speed -= AccelerationRate * 5;
        else if (_speed > 0)
            _speed -= AccelerationRate;
        else
            _speed += AccelerationRate;
    }

    private void RotateLeft()
    {
        gameObject.transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);
    }

    private void RotateRight()
    {
        gameObject.transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }

    private void DeWarp()
    {
        Shrink();

        if (_warpTime > 0)
            _warpTime = 0;

        _controller.SetJumpCountdown(_warpTime);

        if (_isWarping)
        {
            _warpAudio.Stop();

            _isWarping = false;
        }
    }

    private void Stretch()
    {
        var newXScale = gameObject.transform.localScale.x + 0.1f;

        var xScale = Math.Min(newXScale, 10);

        if (gameObject.transform.localScale.x < 10)
            gameObject.transform.localScale = new Vector3(xScale, 1, 1);
    }

    private void Shrink()
    {
        var newXScale = gameObject.transform.localScale.x - 0.5f;

        var xScale = Math.Max(newXScale, 1);

        if (gameObject.transform.localScale.x > 1)
            gameObject.transform.localScale = new Vector3(xScale, 1, 1);
    }

    private void CreateImpulseBubbles()
    {
        var warpBubbles = gameObject.GetComponentInChildren<ParticleSystem>();

        warpBubbles.emissionRate = Math.Abs(_speed);

        if(HasWarp)
            warpBubbles.startColor = new Color(0, 200, 255);
    }
}
