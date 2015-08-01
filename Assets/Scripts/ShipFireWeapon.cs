using UnityEngine;
using System.Collections;

public class ShipFireWeapon : MonoBehaviour
{
    private Object _torpedo;

    void Start () 
    {
        _torpedo = Resources.Load("Prefabs/Photon Torpedo");
	}
	
	public void FirePrimaryWeapon()
	{
	    var position = gameObject.transform.position;

	    var rotation = gameObject.transform.rotation;

	    Instantiate(_torpedo, position, rotation);
	}
}
