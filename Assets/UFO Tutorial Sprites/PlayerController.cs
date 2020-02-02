using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private int count;
    private int playerLive;
    public Text countText;
    public Text winText;
    public Text PlayerLivesText;
    


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        playerLive = 3;
        winText.text = "";
        SetCountText();
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 Movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(Movement * speed);
        
    }
   
        
        
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))

        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            playerLive = playerLive - 1;
            SetCountText();
        }
        if (count == 12) 
{
    transform.position = new Vector2(100.0f, 0.0f); 
}
    }
    void SetCountText()

    {
        PlayerLivesText.text = "Player Lives :" + playerLive.ToString();
        countText.text = "count:" + count.ToString();
        if (count >= 20)
        {
            winText.text = "You win! Game created by HangZheng!";
        }
        else if(playerLive <=0)
        {
            Destroy(gameObject);
            winText.text = "You Lose";

        }
    }
    }