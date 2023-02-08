using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Controller : MonoBehaviour
{

    public float bounceForce;
    // dung cho chim nay len
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    [SerializeField] //hien nen duoc khi van de private
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, dieClip;

    private bool isAlive; //false
    private bool didFlap; //false
    private void Awake() // Khoi tao nhan gia tri 
    {
        isAlive = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() // dung de xu ly chuyen dong // vat ly
    {
        _BirdMove();
    }

    void _BirdMove()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, bounceForce);
            audioSource.PlayOneShot(flyClip);
        }*/

        if(isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        if (rigidbody2D.velocity.y > 0) 
        {
            float angel = 0; // xoay chatacter
            angel = Mathf.Lerp(0, 45    , rigidbody2D.velocity.y / 8);
            // tinh goc noioj suy
            Debug.Log(rigidbody2D.velocity + " day la 1");
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }else if (rigidbody2D.velocity.y == 0)  
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if (rigidbody2D.velocity.y < 0) 
        {
            float angel = 0; // xoay chatacter
            angel = Mathf.Lerp(0, -45, -rigidbody2D.velocity.y / 8);
            // tinh goc noioj suy
            Debug.Log(rigidbody2D.velocity + "day la 2");
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    // Update is called once per frame
    void Update()   // dung de xu ly tinh toan // vi tri
    {
        
    }

    public void BtnFlap()
    {
        didFlap = true;
    }

}
