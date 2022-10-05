using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D m_rb;

    /*private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }*/
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKey(KeyCode.Space))
        {
            if (m_rb)
            {
                m_rb.AddForce(Vector2.up * jumpForce);
            }
        }*/
    }
}
