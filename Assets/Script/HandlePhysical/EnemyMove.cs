using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
 
    public float PowEnemy;

    //check have ball
    private bool haveBall;
    public GameObject enemyPrefab;

    //move random enemy
    public NavMeshAgent agent;

    //set position go to
    public Vector3 position;
    public float xPos;
    public float yPos;
    public float zPos;


    public Transform PosBall;
    public GameObject Ball;

    private GameObject copyBall;


    private GameObject hand;

    private Transform[] ChildTransforms;

    private Vector3 directionEnemy;

    void Start()
    {
        StartCoroutine(MoveEnemy(2.0f));
        haveBall = false;

        hand = GameObject.Find("ObstaclePlayer");
        //direction();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* void direction()
    {
        hand = GameObject.Find("ObstaclePlayer");
        ChildTransforms = new Transform[hand.transform.childCount];
        for (int i = 0; i < hand.transform.childCount; i++)
        {
            ChildTransforms[i] = hand.transform.GetChild(i);
        }

        Debug.Log(ChildTransforms);
    }*/


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Destroy(collision.gameObject);
            haveBall = true;
        }
        spawnBall();
        StartCoroutine(ThrowEnemy(2.0f));
    }

    void spawnBall()
    {
        copyBall = Instantiate(Ball, gameObject.transform.position + new Vector3(1, 0, 1), Quaternion.identity);
        copyBall.transform.GetComponent<Collider>().tag = "Enemy";
        copyBall.GetComponent<Rigidbody>().isKinematic = true;
        

      
    }

    IEnumerator ThrowEnemy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (haveBall)
        {
            int index = Random.Range(0, hand.transform.childCount);
            Transform target = hand.transform.GetChild(index);
            directionEnemy = target.position - copyBall.transform.position;
            directionEnemy.x = Random.Range(directionEnemy.x - 10f, directionEnemy.x + 10f);
            directionEnemy.z = Random.Range(directionEnemy.z - 10f, directionEnemy.z + 10f);
            copyBall.GetComponent<Rigidbody>().isKinematic = false;
            copyBall.GetComponent<Rigidbody>().AddForce(directionEnemy.normalized * PowEnemy, ForceMode.VelocityChange);
            haveBall = false;
        }
    }

    IEnumerator spawEnemy(float waitTime)
    {
        Vector3 spawnPos = Vector3.zero;
        yield return new WaitForSeconds(waitTime);

        spawnPos.x = Random.Range(-9f, 9f);
        spawnPos.y = 0;
        spawnPos.z = 5f;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    IEnumerator MoveEnemy(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);

        xPos = Random.Range(-15.0f, 14.5f);
        zPos = Random.Range(8.0f, 25.0f);
        position = new Vector3(xPos, 0.5f, zPos);
        if (haveBall)
        {
            agent.SetDestination(gameObject.transform.position);
        }
        else
        {
            agent.SetDestination(position);
        }
        StartCoroutine(MoveEnemy(2.0f));
    }
}
