using UnityEngine;
using System.Collections;

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

        Instantiate(_explosion, asteroidPosition, rotation);

        var camera = GameObject.FindGameObjectWithTag("MainAudio");

        var explosionAudio = camera.AddComponent<AudioSource>();

        explosionAudio.clip = _explosionClip;

        explosionAudio.Play();

        var size = asteroid.transform.localScale.x;

        if (size > 1.5f)
            CreateChildAsteroids(asteroidPosition, size);

        Destroy(asteroid);

        Destroy(gameObject);

        _gameController.AddToScore(100);        
    }

    private void CreateChildAsteroids(Vector3 position, float size)
    {
        var childSize = size / 2f;

        CreateChildAsteroid(position, childSize);

        CreateChildAsteroid(position, childSize);
    }

    private void CreateChildAsteroid(Vector3 position, float size)
    {
        var asteroid = Resources.Load("Prefabs/Asteroid");

        var rotation = new Quaternion(0f, 0f, 0f, 0f);

        var gameObject = (GameObject)Instantiate(asteroid, position, rotation);

        gameObject.transform.localScale = new Vector3(size, size, size);
    }
}
