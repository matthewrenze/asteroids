using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class TorpedoCollision : MonoBehaviour
{
    private GameController _gameController;
    private Object _explosion;
    private AudioClip _explosionClip;

    void Start()
    {
        _gameController =  GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        _explosion = Resources.Load("Prefabs/Explosion");

        _explosionClip = Resources.Load<AudioClip>("Sounds/explosion");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.tag.Equals("Asteroid")) 
            return;

        var asteroid = collider.gameObject;

        var asteroidPosition = asteroid.transform.position;

        var rotation = Quaternion.identity;

        var asteroidMovement = asteroid.GetComponentInChildren<AsteroidMovement>();

        var direction = asteroidMovement.Direction;

        Instantiate(_explosion, asteroidPosition, rotation);

        var camera = GameObject.FindGameObjectWithTag("MainAudio");

        var explosionAudio = camera.AddComponent<AudioSource>();

        explosionAudio.clip = _explosionClip;

        explosionAudio.Play();

        var size = asteroid.transform.localScale.x;

        if (size > 1.5f)
            CreateChildAsteroids(asteroidPosition, direction, size);

        Destroy(asteroid);

        Destroy(gameObject);

        _gameController.AddToScore(100);        
    }

    private void CreateChildAsteroids(Vector3 position, Vector3 direction, float size)
    {
        CreateChildAsteroid(position, direction, size);

        CreateChildAsteroid(position, direction, size);
    }

    private void CreateChildAsteroid(Vector3 position, Vector3 direction, float size)
    {
        var asteroid = Resources.Load("Prefabs/Asteroid");

        var rotation = new Quaternion(0f, 0f, 0f, 0f);

        var childSize = size / 2f;

        var gameObject = (GameObject)Instantiate(asteroid, position, rotation);

        gameObject.transform.localScale = new Vector3(childSize, childSize, childSize);

        var x = Math.Abs(direction.x);

        var y = Math.Abs(direction.y);

        var mx = Random.Range(-x, x);

        var my = Random.Range(-y, y);

        var mz = 0f;

        var childDirection = new Vector3(mx, my, mz);

        var movement = gameObject.GetComponentInChildren<AsteroidMovement>();

        movement.Direction = childDirection;
    }
}
