using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D RBtop;
    public float tophiz = 5f;
    public Text tOyuncu1, tOyuncu2;
    public int Scoreoyuncu1, Scoreoyuncu2;
    public bool isScore;
    void Start()
    {
        RBtop = GameObject.Find("Top").GetComponent<Rigidbody2D>();

        tOyuncu1 = GameObject.Find("ScoreOyuncu1").GetComponent<Text>();
        tOyuncu2 = GameObject.Find("ScoreOyuncu2").GetComponent<Text>();

        BallController();
    }

    // Update is called once per frame
    void Update()
    {
        tOyuncu1.text = "P1: "+Scoreoyuncu1.ToString();
        tOyuncu2.text = "P2: "+Scoreoyuncu2.ToString();

        if (isScore == true && Input.GetKeyDown(KeyCode.Space))
        {
            BallController();
            isScore = false;
        }
    }

    public void BallController()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        RBtop.velocity = new Vector2(x * tophiz, y * tophiz);

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Sol"))
        {
            Scoreoyuncu2++;
            RBtop.position = new Vector2(0, 0);
            RBtop.velocity = new Vector2(0, 0);
            isScore = true;
            // veya Invoke("BallController",2);
        }
        if (other.gameObject.CompareTag("Sag"))
        {
            Scoreoyuncu1++;
            RBtop.position = new Vector2(0, 0);
            RBtop.velocity = new Vector2(0, 0);
            isScore = true;
            // veya Invoke("BallController",2);
        }
        
        
    }
    
    
}
