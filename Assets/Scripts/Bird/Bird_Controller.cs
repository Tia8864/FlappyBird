using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Controller : MonoBehaviour
{
    public static Bird_Controller _Instance;

    private float bounceForce;
    // dung cho chim nay len
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private GameObject spwanPipe;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flyClip, pingClip, dieClip;

    public bool isAlive = true; //false
    private bool didFlap; //false
    public int point = 0;
    private void Awake() // Khoi tao nhan gia tri 
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spwanPipe = GameObject.Find("SpwanPipe");
        bounceForce = ManagerGame._Instance.bounceForce;
    }


    private void FixedUpdate() // dung de xu ly chuyen dong // vat ly
    {
        _BirdMove();
    }
    private float timelerp;
    private void Update()
    {
        timelerp += Time.deltaTime;
        _GoPos();
    }
    private void _GoPos()
    {
        if (transform.position.x >= -1f)
        {
            Vector3 temp = transform.position;
            temp.x -= ManagerGame._Instance.speedPipes * Time.deltaTime;
            transform.position = temp;
        }
    }

    void _BirdMove()
    {
        if (isAlive)
        {
            animator.SetBool("isDie", false);
            if (didFlap)
            {
                didFlap = false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }

            if (rigidbody2D.velocity.y > 0)
            {
                float angel = 0; // xoay chatacter
                angel = Mathf.Lerp(0, 45, rigidbody2D.velocity.y / 8);
                // tinh goc noioj suy
                /*Debug.Log(rigidbody2D.velocity + " day la 1");*/
                transform.rotation = Quaternion.Euler(0, 0, angel);
            }
            else if (rigidbody2D.velocity.y == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (rigidbody2D.velocity.y < 0)
            {
                float angel = 0; // xoay chatacter
                angel = Mathf.Lerp(0, -45, -rigidbody2D.velocity.y / 8);
                // tinh goc noioj suy
                /*Debug.Log(rigidbody2D.velocity + "day la 2");*/
                transform.rotation = Quaternion.Euler(0, 0, angel);
            }
        }
    }

    public void _BtnFlap()
    {
        didFlap = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Taget")
        {
            audioSource.PlayOneShot(pingClip);
            point++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {
            isAlive = false;
            rigidbody2D.velocity = Vector2.zero;
            audioSource.PlayOneShot(dieClip);
            animator.SetBool("isDie", true);
            /*spwanPipe.SetActive(false);*/
        }

        if(collision.gameObject.tag == "Ground")
        {
            Time.timeScale = 0;
            isAlive = false;
            rigidbody2D.velocity = Vector2.zero;
            audioSource.PlayOneShot(dieClip);
            animator.SetBool("isDie", true);
        }
    }


}
