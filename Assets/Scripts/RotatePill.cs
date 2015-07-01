using UnityEngine;
using System.Collections;

public class RotatePill : MonoBehaviour
{
    public int Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        gameObject.transform.Rotate(-Speed * Time.deltaTime, 0, 0, Space.Self);
	}
}
