using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Movement
    [Header("Movement")]
    public float speed;
    public float HorizInput;

    //Jumping
    [Header("Jumping")]
    public bool IsOnground;
    public float JumpForce;

    //Animation
    [Header("Animation booleans")]
    public bool IsWalking;
    public bool IsAttacking;
    public bool IsChoicing;

    //Controls
    [Header("Controls")]
    public KeyCode Jumpkey;
    public KeyCode Attackkey;
    public KeyCode Choicekey;

    //Components
    [Header("Components")]
    public Animator Anim;
    public Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        //Declarations
        Anim = gameObject.GetComponent<Animator>();
        Rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Animator declarations
        Anim.SetBool("IsWalking", IsWalking);
        Anim.SetBool("IsJumping", IsOnground);
        Anim.SetBool("IsAttacking", IsAttacking);
        Anim.SetBool("IsActing", IsChoicing);

        //Declarations
        HorizInput = Input.GetAxis("Horizontal");

        //Walking
        transform.Translate(Vector2.right * HorizInput * speed * Time.deltaTime );

        if(HorizInput < 0)
        {
            IsWalking = true;
        }
        else if (HorizInput > 0)
        {
            IsWalking = true;
        }
        else
        {
            IsWalking = false;
        }



        //Jumping
        if(Input.GetKeyDown(Jumpkey) &&  IsOnground == true)
        {
            Rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsOnground = false;
        }

        //Attacking
        if (Input.GetKeyDown(Attackkey))
        {
            IsAttacking = true;
        }
        else
        {
            IsAttacking = false;
        }

        //Choice
        if (Input.GetKeyDown(Choicekey))
        {
            IsChoicing = true;
        }
        else
        {
           IsChoicing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnground = true;
        }
        else
        {
            IsOnground = false;
        }
    }
}
