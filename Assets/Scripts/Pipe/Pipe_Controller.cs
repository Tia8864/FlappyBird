using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Controller : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private GameObject SpwanPipe;

    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        if(Bird_Controller._Instance != null)
        { 
            /*if(Bird_Controller._Instance.flag == 1)
            {
                Destroy(GetComponent<Pipe_Controller>());
            }else if(Bird_Controller._Instance.flag == 0)
            {
                _PipeMove();
            }
            ---------------------pipe movement------------------------
             */

        }
        /*if (ManagerGUI._Instance.flagResetPipe)
        {
            _SelfDestoy();
            ManagerGUI._Instance.flagResetPipe = false;
        }*/
        
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
            Destroy(gameObject);
        }
    }
    public void _ResetPipe()
    {
        if (!SpwanPipe.gameObject.TryGetComponent(out Pipe_Controller isExists))
        {
            SpwanPipe.gameObject.AddComponent<Pipe_Controller>();
        }
    }

    public void _SelfDestoy()
    {
        Destroy(gameObject);
        Debug.Log("delete this");
    }
}
