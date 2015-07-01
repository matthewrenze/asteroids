using UnityEngine;
using System.Collections;

public class ShipFireTorpedo : MonoBehaviour
{
    private Object _torpedo;

    // Use this for initialization
	void Start () 
    {
        _torpedo = Resources.Load("Prefabs/Photon Torpedo");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!Input.GetKeyDown(KeyCode.Space)) 
            return;

	    var position = gameObject.transform.position;

	    var rotation = gameObject.transform.rotation;

	    Instantiate(_torpedo, position, rotation);
	}
}
