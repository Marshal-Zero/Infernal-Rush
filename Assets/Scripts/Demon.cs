using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 100f;

    private Animator anim;
    private Rigidbody rigidBody;
    private bool jump = false;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStartedGame();
                anim.Play("Jump");
                rigidBody.useGravity = true;
                jump = true;

            }
        }

        
    }

    private void FixedUpdate()
    {
        if (jump == true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            anim.Play("Death");
            rigidBody.AddForce(new Vector2(50, -20), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            GameManager.instance.PlayerCollided();
        }
    }
}
