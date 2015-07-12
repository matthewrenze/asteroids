using UnityEngine;
using System.Collections;

public class CameraChase : MonoBehaviour
{
    public bool IsChase = false;
    
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

	    if (Input.GetKeyDown(KeyCode.LeftAlt))
	        IsChase = !IsChase;

	    if (IsChase)
	        ShowChase();
	    else
	        ShowOverhead();
    }

    private void ShowOverhead()
    {
        var x = Player.transform.position.x + 15f;

        var y = Player.transform.position.y + 15f;

        var z = Player.transform.position.z;

        gameObject.transform.position = new Vector3(x, y, z);

        var rx = -0.3f;

        var ry = 0.7f;

        var rz = -0.3f;

        var rw = -0.7f;

        gameObject.transform.rotation = new Quaternion(rx, ry, rz, rw);
    }

    private void ShowChase()
    {
        var x = Player.transform.position.x + 7.5f;

        var y = Player.transform.position.y + 2.5f;

        var z = Player.transform.position.z;

        gameObject.transform.position = new Vector3(x, y, z);

        var rx = 0.0f;

        var ry = 0.7f;

        var rz = 0.0f;

        var rw = -0.7f;

        gameObject.transform.rotation = new Quaternion(rx, ry, rz, rw);
    }
}
