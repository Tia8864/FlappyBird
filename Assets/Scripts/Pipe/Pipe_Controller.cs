using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Controller : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Pipe_Spwan._Instance.speedPipe;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird_Controller._Instance.isAlive)
            _PipeMove();
    }

    private void _PipeMove()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
