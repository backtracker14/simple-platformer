using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    float MoveHorizontal;
    float MoveVertical;
    public float jumpForce;
    public float speed;
    Animator anm;
    Rigidbody2D rb;
    SpriteRenderer sp;
    bool anm_Jump;
    bool anm_Walk;
    public int coinCounter;
    public Text coins;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anm = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(MoveHorizontal * speed, 0, 0);
        MoveVertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, MoveVertical * jumpForce, 0);

        if(MoveHorizontal > 0)
        {
            // flip.x=false;
            sp.flipX = false;
        }
        else if(MoveHorizontal < 0)
        {
            // flip.x=true;
            sp.flipX = true;
        }

        if(MoveHorizontal != 0 )
        {
            anm.SetBool("isWalking", true);
        }

        if(MoveHorizontal == 0)
        {
            anm.SetBool("isWalking", false);
        }

        if(MoveVertical != 0)
        {
            anm.SetBool("isJumping", true);

        }
        if(MoveVertical == 0)
        {
            anm.SetBool("isJumping", false);
        }

    pprivate void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            coinCounter++;

            //Debug.Log(Counter);
            coinText.text = coinCounter.ToString();
        }
    }


    
    }

}
