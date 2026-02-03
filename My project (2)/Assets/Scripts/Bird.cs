using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 200f;
    [SerializeField] private Sprite jump;
    [SerializeField] private Sprite fall;
    private SpriteRenderer spriteRenderer;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale > 0)
            {
                //add jump rb force
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
                GameController.Instance.OnJumped();
            }
            else
            {
                //reset game
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f;
            }
        }

        // Update sprite based on velocity
        if (rb.velocity.y > 0)
        {
            spriteRenderer.sprite = jump;
        }
        else if (rb.velocity.y < 0)
        {
            spriteRenderer.sprite = fall;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            //player score change
            score++;
            GameController.Instance.OnScoreChanged(score);
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        GameController.Instance.OnDied();
    }
}
