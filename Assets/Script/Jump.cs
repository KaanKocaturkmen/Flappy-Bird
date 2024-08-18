using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    public Text pointText, avgPointText;
    public AudioSource pointGained, gameOver;
    public int point;
    public int avgPoint;
    public float jumpForce = 5;
    public bool stop = false;
    public GameObject Panel;
    public GameObject StartPanel;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPanel.SetActive(true);
        stop = false;
        Time.timeScale = 0;
    }

    void Update()
    {
        pointText.text = point.ToString();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.velocity = Vector2.up * jumpForce;
            Time.timeScale = (Time.timeScale == 0) ? 1 : Time.timeScale;
            if (StartPanel.activeSelf)
            { 
                StartPanel.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && stop) {
            SceneManager.LoadScene("Level-1");
            Time.timeScale = 1;
        }

        if (transform.position.y > 4.40)
        {
            transform.position = new Vector2(-6, 4.3f);
        }
        if (transform.position.y < -5.5)
        {
            ResetLevel();
            transform.position = new Vector2(-6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Point")
        {
            point++;
            pointGained.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pipe") 
        {
            ResetLevel();
        }
    }

    private void ResetLevel()
    {
        stop = true;
        Time.timeScale = 0;
        gameOver.Play();
        Panel.SetActive(true);
    }
}
