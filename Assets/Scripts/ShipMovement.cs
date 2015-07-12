using System;
using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    public float AccelerationRate = 0.1f;
    public float MovementSpeed = 0.5f;
    public float WarpSpeed = 100f;
    public float RotationSpeed = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    HandleMovement();

	    HandleRotation();
        
	    CreateImpulseBubbles();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow)
            && Input.GetKey(KeyCode.LeftControl))
            Warp();

        else if (Input.GetKey(KeyCode.UpArrow))
            MoveForward();

        else if (Input.GetKey(KeyCode.DownArrow))
            MoveBackward();

        else
            Decelerate();

        gameObject.transform.Translate(-MovementSpeed*Time.deltaTime, 0, 0);

        if (!Input.GetKey(KeyCode.UpArrow)
            || !Input.GetKey(KeyCode.LeftControl))
            UnWarp();
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
        gameObject.transform.Translate(-WarpSpeed*Time.deltaTime, 0, 0);

        gameObject.transform.localScale =
            new Vector3(gameObject.transform.localScale.x + 0.1f, 1, 1);
    }

    private void MoveForward()
    {
        if (MovementSpeed < 10)
            MovementSpeed += AccelerationRate;        
    }

    private void MoveBackward()
    {
        if (MovementSpeed > -10)
            MovementSpeed -= AccelerationRate;
    }

    private void Decelerate()
    {
        if (MovementSpeed > 0)
            MovementSpeed -= AccelerationRate;
        else
            MovementSpeed += AccelerationRate;
    }

    private void RotateLeft()
    {
        gameObject.transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
    }

    private void RotateRight()
    {
        gameObject.transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }

    private void UnWarp()
    {
        var newXScale = gameObject.transform.localScale.x - 0.5f;

        var xScale = Math.Max(newXScale, 1);

        if (gameObject.transform.localScale.x > 1)
            gameObject.transform.localScale =
                new Vector3(xScale, 1, 1);
    }

    private void CreateImpulseBubbles()
    {
        var warpBubbles = gameObject.GetComponentInChildren<ParticleSystem>();

        warpBubbles.emissionRate = Math.Abs(MovementSpeed);
    }
}
