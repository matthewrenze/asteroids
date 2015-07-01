using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class PillCollision : MonoBehaviour
{
    private Object _explosion;

    void Start()
    {
        _explosion = Resources.Load("Prefabs/Explosion");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.tag.Equals("Player")) 
            return;

        var pillPosition = collider.gameObject.transform.position;

        var rotation = Quaternion.identity;

        Instantiate(_explosion, pillPosition, rotation);

        gameObject.GetComponent<AudioSource>().Play();

        Destroy(gameObject, gameObject.GetComponent<AudioSource>().clip.length);

        var shield = GameObject.FindGameObjectWithTag("Shield");                

        shield.GetComponent<MeshRenderer>().enabled = true;

        shield.GetComponent<SphereCollider>().enabled = true;
    }
}
