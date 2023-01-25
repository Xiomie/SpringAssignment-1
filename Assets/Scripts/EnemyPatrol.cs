using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour

{
    public float moveSpeed = 2f;
    public float moveDistance = 5f;

    private Vector3 startPos;
    private bool movingLeft = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (movingLeft)
        {
            GetComponent<Animator>().Play("Run");
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.position = Vector3.MoveTowards(transform.position, startPos + Vector3.right * moveDistance, moveSpeed * Time.deltaTime);
            if (transform.position == startPos + Vector3.right * moveDistance)
            {
                movingLeft = false;
            }
        }
        else
        {
            GetComponent<Animator>().Play("Idle");
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            if (transform.position == startPos)
            {
                movingLeft = true;
            }
        }
    }
}

