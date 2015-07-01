using UnityEngine;
using System.Collections;

public class CameraChase : MonoBehaviour
{
    private GameObject Player;

	// Use this for initialization
	void Start ()
	{
	    Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (Player == null) 
            return;

	    var x = Player.transform.position.x + 15;

	    var y = gameObject.transform.position.y;

	    var z = Player.transform.position.z;

	    gameObject.transform.position = new Vector3(x, y, z);
    }
}
