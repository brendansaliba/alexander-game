using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_control : MonoBehaviour
{
    public float parallaxFactor = 4.0f;
    private GameObject player;
    private Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(playerRigidBody.velocity.x * Time.deltaTime/parallaxFactor, 0, 0);
    }
}
