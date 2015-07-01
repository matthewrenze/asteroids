using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour
{
    private Object _explosion;

    void Start()
    {
        _explosion = Resources.Load("Prefabs/Explosion");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.tag.Equals("Asteroid")) 
            return;

        var asteroidPosition = collider.gameObject.transform.position;

        var rotation = Quaternion.identity;

        Instantiate(_explosion, asteroidPosition, rotation);

        Destroy(collider.gameObject);

        gameObject.GetComponent<MeshRenderer>().enabled = false;

        gameObject.GetComponent<SphereCollider>().enabled = false;

        gameObject.GetComponent<AudioSource>().Play();
    }
}
