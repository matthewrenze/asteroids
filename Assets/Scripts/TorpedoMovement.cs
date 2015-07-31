using UnityEngine;
using System.Collections;

public class TorpedoMovement : MonoBehaviour {

    public float Speed = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        gameObject.transform.Translate(Speed * Time.deltaTime, 0, 0, Space.Self);
	}
}
