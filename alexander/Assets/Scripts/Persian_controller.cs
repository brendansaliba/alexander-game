using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persian_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animation controller
        if (gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
        {
            gameObject.GetComponent<Animator>().Rebind();
        }
    }
}
