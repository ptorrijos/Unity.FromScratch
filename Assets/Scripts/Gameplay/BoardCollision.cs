using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCollision : MonoBehaviour
{
    public AudioSource DestructionClip;
    public GameObject[] ExplosionParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject currentExplosionParticles;

        //Debug.Log("Collision");

        switch(collision.gameObject.name)
        {
            case "ball03":
                currentExplosionParticles = ExplosionParticles[2];
                break;
            case "ball02":
                currentExplosionParticles = ExplosionParticles[1];
                break;
            default:
                currentExplosionParticles = ExplosionParticles[0];
                break;
        }

        DestructionClip.Play();
        var particles = Instantiate(currentExplosionParticles, collision.contactCount > 0 ? collision.contacts[0].point : Vector2.zero, Quaternion.identity);
        particles.GetComponent<ParticleSystem>().Play();
        Destroy(collision.gameObject.transform.parent.gameObject);
        Destroy(particles, 5f);
        GameController.current.BallMissed();
    }
}
