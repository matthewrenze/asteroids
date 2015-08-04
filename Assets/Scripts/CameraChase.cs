using Assets.Scripts;
using UnityEngine;
using System.Collections;

public class CameraChase : MonoBehaviour
{
    public CameraMode CameraMode = CameraMode.Overhead;
    
    private GameObject Player;

	void Start ()
	{
	    Player = GameObject.FindGameObjectWithTag("Player");
	}

    public void DecreaseView()
    {
        if (CameraMode == CameraMode.Overhead)
            CameraMode = CameraMode.FirstPerson;
        else
            CameraMode --;
    }

    public void IncreaseView()
    {
        if (CameraMode == CameraMode.FirstPerson)
            CameraMode = CameraMode.Overhead;
        else
            CameraMode ++;
    }

	public void UpdateCamera()
    {
	    if (Player == null) 
            return;

	    if (CameraMode == CameraMode.Overhead)
	        ShowOverhead();

        else if (CameraMode == CameraMode.Orthogonal)
	        ShowOrthogonal();

        else if (CameraMode == CameraMode.Chase)
            ShowChase();

        else if (CameraMode == CameraMode.FirstPerson)
            ShowFirstPerson();
    }

    private void ShowOverhead()
    {
        var x = Player.transform.position.x;

        var y = Player.transform.position.y;

        var z = Player.transform.position.z + 50f;

        gameObject.transform.position = new Vector3(x, y, z);

        var rx = 0.7f;

        var ry = 0.7f;

        var rz = 0.0f;

        var rw = 0.0f;

        gameObject.transform.rotation = new Quaternion(rx, ry, rz, rw);
    }

    private void ShowOrthogonal()
    {
        var x = Player.transform.position.x - 15f;

        var y = Player.transform.position.y;

        var z = Player.transform.position.z + 15f;

        gameObject.transform.position = new Vector3(x, y, z);

        var rx = -0.7f;

        var ry = -0.7f;

        var rz = -0.4f;

        var rw = -0.4f;

        gameObject.transform.rotation = new Quaternion(rx, ry, rz, rw);
    }

    private void ShowChase()
    {
        var x = Player.transform.position.x - 7.5f;

        var y = Player.transform.position.y;

        var z = Player.transform.position.z + 2.5f;

        gameObject.transform.position = new Vector3(x, y, z);

        var rx = 0.5f;

        var ry = 0.5f;

        var rz = 0.5f;

        var rw = 0.5f;

        gameObject.transform.rotation = new Quaternion(rx, ry, rz, rw);
    }

    private void ShowFirstPerson()
    {
        var x = Player.transform.position.x;

        var y = Player.transform.position.y;

        var z = Player.transform.position.z + 1;

        gameObject.transform.position = new Vector3(x, y, z);

        gameObject.transform.rotation = Player.transform.rotation;

        gameObject.transform.Rotate(0, 90, 90);
    }
}
