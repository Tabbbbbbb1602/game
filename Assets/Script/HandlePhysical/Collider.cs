using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
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

        if (collision.transform.GetComponent<ColliderBall>() != null)

        {
            if (type == TypeT.collide)
            {
                if (collision.transform.GetComponent<ColliderBall>().tag != tag)
                {
                    Destroy(gameObject);
                }
                if (collision.transform.GetComponent<ColliderBall>().tag == tag)
                {
                   
                }

            }


            if(type == TypeT.collided)
            {
                if (collision.transform.GetComponent<ColliderBall>().tag != tag)
                {

                }
                if (collision.transform.GetComponent<ColliderBall>().tag == tag)
                {
                    Destroy(gameObject);
                }
            }

        }
    }
}
