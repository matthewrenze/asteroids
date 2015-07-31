using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

    private Vector3 Direction;

	// Use this for initialization
	void Start ()
	{
	    var x = Random.Range(-3, 3);

	    var y = Random.Range(-3, 3);

	    var z = 0;

	    Direction = new Vector3(x, y, z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        var x = Direction.x * Time.deltaTime;

        var y = Direction.y * Time.deltaTime;

        var z = Direction.z;

        var vector = new Vector3(x, y, z);

	    gameObject.transform.Translate(vector);
	}
}
