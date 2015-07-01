using System;
using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    public float MovementSpeed = 10f;
    public float WarpSpeed = 100f;
    public float RotationSpeed = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetKey(KeyCode.UpArrow) 
            && Input.GetKey(KeyCode.LeftControl))
	    {
            gameObject.transform.Translate(-WarpSpeed * Time.deltaTime, 0, 0);

            gameObject.transform.localScale =
                new Vector3(gameObject.transform.localScale.x + 0.1f, 1, 1);
	    }         

	    else if (Input.GetKey(KeyCode.UpArrow))
	        gameObject.transform.Translate(-MovementSpeed * Time.deltaTime, 0, 0);
	    
        else if (Input.GetKey(KeyCode.DownArrow))
            gameObject.transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            gameObject.transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);

        else if (Input.GetKey(KeyCode.RightArrow))
            gameObject.transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);

        if (!Input.GetKey(KeyCode.UpArrow) 
            || !Input.GetKey(KeyCode.LeftControl))
        {
            var newXScale = gameObject.transform.localScale.x - 0.5f;

            var xScale = Math.Max(newXScale, 1);

	        if (gameObject.transform.localScale.x > 1)
                gameObject.transform.localScale = 
                    new Vector3(xScale, 1, 1);
	    }
	        
    }
}
