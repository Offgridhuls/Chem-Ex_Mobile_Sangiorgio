using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D playerRb;
    public void jump()
    {
       if(PlayerController.instance.isGrounded)
        playerRb.AddForce((Vector2.up * jumpForce));

    }
}
