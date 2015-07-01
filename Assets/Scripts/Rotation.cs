using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public int Speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var delta = Time.deltaTime;

        var angle = Speed * delta;

	    gameObject.transform.Rotate(angle, angle, angle);
	}
}
