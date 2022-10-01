using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBall : MonoBehaviour
{
    public enum TypeT
    {
        collide,
        collided
    }

    public TypeT type;
    public string tag;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.GetComponent<Collider>() != null)
        {
            if (type == TypeT.collide)
            {
                if (collision.transform.GetComponent<Collider>().tag != tag)
                {

                }
                if (collision.transform.GetComponent<Collider>().tag == tag)
                {

                }

            }


            if (type == TypeT.collided)
            {
                if (collision.transform.GetComponent<Collider>().tag != tag)
                {

                }
                if (collision.transform.GetComponent<Collider>().tag == tag)
                {
                    if (tag == "Player")
                    {
                        Debug.Log("collide");

                    }
                    Destroy(gameObject);
                }
            }

        }
    }
}
