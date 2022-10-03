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

 
    //kiểm tra va chạm ở quả bóng => nếu trùng tag thì phá hủy vật thể
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.GetComponent<ColliderObstacle>() != null)
        {
           /* if (type == TypeT.collide)
            {
                if (collision.transform.GetComponent<Collider>().tag != tag)
                {

                }
                if (collision.transform.GetComponent<Collider>().tag == tag)
                {

                }

            }*/


            if (type == TypeT.collided)
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
