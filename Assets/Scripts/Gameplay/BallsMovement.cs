using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsMovement : MonoBehaviour
{
    public float MinSpeed = 1000f;
    public float MaxSpeed = 1000f;
    public float Speed;
    public Time LifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Speed = Random.Range(MinSpeed, MaxSpeed);
        LifeTime = new Time();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.zero - transform.position) * Time.deltaTime * Speed, Space.World);
    }

    void OnDestroy()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.CompareTag("Finish"))
        //{
        //    //Destroy(gameObject.transform.parent.gameObject);
            
        //    gameObject.transform.parent.gameObject.SetActive(false);
        //    GameController.current.BallMissed();
        //    DestructionClip.Play();
        //    Destroy(gameObject.transform.parent.gameObject, 3f);
        //}
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject.transform.parent.gameObject);
            GameController.current.BallCatched();
        }
    }
}
