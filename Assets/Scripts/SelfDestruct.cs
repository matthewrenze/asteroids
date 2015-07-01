using System;
using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    DateTime selfDestructTime;

    public int LifeMilliseconds = 5000;

	// Use this for initialization
	void Start () 
    {
        selfDestructTime = DateTime.Now.AddMilliseconds(LifeMilliseconds);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (DateTime.Now > selfDestructTime)
            Destroy(gameObject);
	}
}
