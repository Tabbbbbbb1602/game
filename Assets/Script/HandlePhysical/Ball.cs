using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Transform enemy;
    // Start is called before the first frame update
    public bool canThrow = false;

    private Rigidbody rb;

    Vector3 lastVelocity;

    public float PowEnemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemy = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);

        /*  if (collision.gameObject.tag == "ObstaclePlayer")
          {
              Debug.Log("abc");
              Destroy(collision.gameObject);
          }*/

    }
}


