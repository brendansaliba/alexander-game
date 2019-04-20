using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move_prot : MonoBehaviour
{

    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public int bouncePower = 1500;
 
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }

        //animation

        //player direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }

        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;

    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 0.9f && hit.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouncePower);

            Destroy(hit.collider.gameObject);
        }
    }

}
