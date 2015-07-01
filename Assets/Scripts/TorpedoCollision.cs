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

        var asteroidPosition = collider.gameObject.transform.position;

        var rotation = Quaternion.identity;

        Instantiate(_explosion, asteroidPosition, rotation);

        var camera = GameObject.FindGameObjectWithTag("MainAudio");

        var explosionAudio = camera.AddComponent<AudioSource>();

        explosionAudio.clip = _explosionClip;

        explosionAudio.Play();

        Destroy(collider.gameObject);

        Destroy(gameObject);

        _gameController.AddToScore(100);
    }
}
