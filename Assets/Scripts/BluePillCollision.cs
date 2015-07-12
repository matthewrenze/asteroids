using UnityEngine;
using System.Collections;

public class BluePillCollision : MonoBehaviour {

    private Object _explosion;
    private AudioClip _sound;

    void Start()
    {
        _explosion = Resources.Load("Prefabs/Explosion");

        _sound = Resources.Load<AudioClip>("Sounds/success");
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

        var ship = GameObject.FindGameObjectWithTag("Player");

        var script = (ShipMovement) ship.GetComponent("ShipMovement");

        script.HasWarp = true;
    }
}
