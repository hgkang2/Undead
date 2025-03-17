using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Vector2 inputVec;
   public float speed;
   Rigidbody2D rigid;
   SpriteRenderer Spriter;
   Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //위치이동
        rigid.MovePosition(rigid.position + nextVec);
    }
    void LateUpdate()
    {
        anim.SetFloat("Speed",inputVec.magnitude);
        
        if(inputVec.x != 0)
        {
            Spriter.flipX = inputVec.x < 0;
        }
    }
}
