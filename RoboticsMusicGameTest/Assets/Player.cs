using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    bool onGround;
    public AudioSource jumpSound;
    public AudioSource landSound;
    public AudioSource coinSound;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        onGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector2.left) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector2.right) * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            onGround = true;
            jumpSound.Play();
        }

        /*if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector2.down) * speed * Time.deltaTime);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            onGround = true;
            landSound.Play();
        }

        if (other.gameObject.tag == "Coin")
        {
            coinSound.Play();
            coin.SetActive(false);
        }
    }
}
