﻿using UnityEngine;
using System.Collections;

public class CreateAsteroids : MonoBehaviour {

    public int AsteroidCount = 1000;
    public float FieldXMin = 100f;
    public float FieldXMax = 200f;
    public float FieldYMin = -100f;
    public float FieldYMax = 100f;
    public float ScaleMin = 0.75f;
    public float ScaleMax = 3f;

	// Use this for initialization
	void Start () 
    {
        var asteroid = Resources.Load("Prefabs/Asteroid");

        for (var i = 0; i < AsteroidCount; i++)
        {
            var x = Random.Range(FieldXMin, FieldXMax);

            var y = Random.Range(FieldYMin, FieldYMax);

            var z = 0f;

            var position = new Vector3(x, y, z);

            var rotation = new Quaternion(0f, 0f, 0f, 0f);

            var gameObject = (GameObject)Instantiate(asteroid, position, rotation);

            var scale = Random.Range(ScaleMin, ScaleMax);

            gameObject.transform.localScale = new Vector3(scale, scale, scale);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
