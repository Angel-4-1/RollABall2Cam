using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource pick;
    public AudioSource badPick;

    private Rigidbody rb;
    private int count;
    private int goodPickUps;
    private int collected;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        goodPickUps = 13;
        collected = goodPickUps;
        SetCountText();
        winText.text = "";
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            collected--;
            pick.Play();
            SetCountText();
        }

        if (other.gameObject.CompareTag("Bad Pick Up"))
        {
            other.gameObject.SetActive(false);
            count--;
            badPick.Play();
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (collected == 0)
        {
            if (count == goodPickUps)
            {
                winText.text = "You Win!";
            }
            else
            {
                winText.text = "Game over!";
            }
        }
    }
}
