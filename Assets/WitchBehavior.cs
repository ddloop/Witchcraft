using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WitchBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rb;
    private bool isJumping = false;

    internal void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            //animator.Play("Jump", 0);
            rb.AddForce(Vector3.up * 320);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += 2 * Time.deltaTime * Vector3.right;
        rb.AddForce(Vector3.right * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.totalForce.y < 1 && collision.collider.name.Contains("MagicTile"))
        {
            if (isJumping)
                isJumping = false;
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.collider.name.Contains("MagicTile"))
    //    {
    //        if (isJumping)
    //            isJumping = false;
    //    }
    //}
}
