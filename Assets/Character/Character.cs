using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Movement
    [Header("Movement")]
    public float speed;
    public float HorizInput;

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


        //Walking
        transform.Translate(Vector2.right * HorizInput * speed * Time.deltaTime );


        //Jumping


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
}
