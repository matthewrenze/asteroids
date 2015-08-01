using UnityEngine;
using System.Collections;

public class CreateAsteroids : MonoBehaviour {

    public int AsteroidCount = 1000;
    public float MinFieldX = 100f;
    public float MaxFieldX = 200f;
    public float MinFieldY = -100f;
    public float MaxFieldY = 100f;
    public float MinSize = 0.75f;
    public float MaxSize = 3f;
    public float MinSpeed = -5f;
    public float MaxSpeed = 5f;

	// Use this for initialization
	void Start () 
    {
        var asteroid = Resources.Load("Prefabs/Asteroid");

        for (var i = 0; i < AsteroidCount; i++)
        {
            var x = Random.Range(MinFieldX, MaxFieldX);

            var y = Random.Range(MinFieldY, MaxFieldY);

            var z = 0f;

            var position = new Vector3(x, y, z);

            var rotation = new Quaternion(0f, 0f, 0f, 0f);

            var gameObject = (GameObject)Instantiate(asteroid, position, rotation);

            var scale = Random.Range(MinSize, MaxSize);

            gameObject.transform.localScale = new Vector3(scale, scale, scale);

            var movement = gameObject.GetComponentInChildren<AsteroidMovement>();

            var mx = Random.Range(MinSpeed, MaxSpeed);

	        var my = Random.Range(MinSpeed, MaxSpeed);

	        var mz = 0f;

	        var direction = new Vector3(mx, my, mz);

            movement.Direction = direction;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
