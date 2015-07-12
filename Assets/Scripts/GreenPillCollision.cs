using UnityEngine;
using System.Collections;

public class GreenPillCollision : MonoBehaviour {

    private Object _explosion;
    private AudioClip _sound;

    void Start()
    {
        _explosion = Resources.Load("Prefabs/Explosion");

        _sound = Resources.Load<AudioClip>("Sounds/shields-up");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.tag.Equals("Player"))
            return;

        var pillPosition = collider.gameObject.transform.position;

        var rotation = Quaternion.identity;

        Instantiate(_explosion, pillPosition, rotation);

        var mainAudio = GameObject.FindGameObjectWithTag("MainAudio");

        var audio = mainAudio.AddComponent<AudioSource>();

        audio.clip = _sound;

        audio.Play();

        Destroy(gameObject);

        var shield = GameObject.FindGameObjectWithTag("Shield");

        shield.GetComponent<MeshRenderer>().enabled = true;

        shield.GetComponent<SphereCollider>().enabled = true;
    }
}
