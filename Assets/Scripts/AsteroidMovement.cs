using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

    private Vector3 Direction;

	// Use this for initialization
	void Start ()
	{
	    var x = Random.Range(-3, 3);

	    var y = 0;

	    var z = Random.Range(-3, 3);

	    Direction = new Vector3(x, y, z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        var x = Direction.x * Time.deltaTime;

	    var y = Direction.y;

        var z = Direction.z * Time.deltaTime;

        var vector = new Vector3(x, y, z);

	    gameObject.transform.Translate(vector);
	}
}
