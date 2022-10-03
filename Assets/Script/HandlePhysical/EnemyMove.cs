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

    Animator m_animator;

    void Start()
    {
        StartCoroutine(MoveEnemy(2.0f));
        haveBall = false;

        hand = GameObject.Find("ObstaclePlayer");
        //direction();

    }

    private void Awake()
    {
        m_animator = gameObject.GetComponent<Animator>();
        m_animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            m_animator.SetBool("isRunning", false);
            Destroy(collision.gameObject);
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            haveBall = true;
        }
        spawnBall();
        StartCoroutine(ThrowEnemy(2.0f));
    }

    void spawnBall()
    {
        copyBall = Instantiate(Ball, gameObject.transform.position + new Vector3(1.0f, 1.5f, 3.0f), Quaternion.identity);
        copyBall.transform.GetComponent<ColliderBall>().tag = "Enemy";
        copyBall.GetComponent<Rigidbody>().isKinematic = true;
        copyBall.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
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
            StartCoroutine(SetIsTrigger(0.5f));
            m_animator.SetBool("isRunning", true);
            haveBall = false;
        }
    }

    IEnumerator SetIsTrigger(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
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
