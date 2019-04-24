using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyMove : MonoBehaviour
{

    public int EnemySpeed;
    public int XMoveDirection;
    private SpriteRenderer mySpriteRenderer;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 1.2f && hit.distance > 0)
        {
            Flip();
            if (hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
                Flip();
                SceneManager.LoadScene("grassy scene");
                
            }
        }
    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            mySpriteRenderer.flipX = true;
        }
        else
        {
            XMoveDirection = 1;
            mySpriteRenderer.flipX = true;
        }
    }
}
