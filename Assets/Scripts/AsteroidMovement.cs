using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

    public Vector3 Direction;
		
	void Update () 
    {
        var x = Direction.x * Time.deltaTime;

        var y = Direction.y * Time.deltaTime;

        var z = Direction.z;

        var vector = new Vector3(x, y, z);

	    gameObject.transform.Translate(vector);
	}
}
