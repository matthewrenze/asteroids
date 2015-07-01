using UnityEngine;
using System.Collections;

public class CreateAsteroids : MonoBehaviour {

    public int AsteroidCount = 1000;

	// Use this for initialization
	void Start () 
    {
        var asteroid = Resources.Load("Prefabs/Asteroid");

	    for (var i = 0; i < AsteroidCount; i++)
	    {
            var x = Random.Range(-200, -100);

            var y = 0;

            var z = Random.Range(-100, 100);

            var position = new Vector3(x, y, z);

            var rotation = new Quaternion(0f, 0f, 0f, 0f);

            var gameObject = (GameObject) Instantiate(asteroid, position, rotation);

            var scale = Random.Range(0.75f, 3f);

            gameObject.transform.localScale = new Vector3(scale, scale, scale);
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
