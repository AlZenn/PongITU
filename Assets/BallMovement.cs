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

public int P1Health = 2;
public int P2Health = 2;
public GameObject P1Kalkan, P1Can, P2Kalkan, P2Can;

    void Start()
    {
        P1Health = 2;
        P2Health = 2;


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

        if (P1Health == 2)
        {
            P1Kalkan.SetActive(true);
            P1Can.SetActive(true);
        }
        else if (P1Health == 1)
        {
            P1Kalkan.SetActive(false);
            P1Can.SetActive(true);
        }
        else if (P1Health == 0)
        {
            P1Kalkan.SetActive(false);
            P1Can.SetActive(false);
            // game over panel
        }
        if (P2Health == 2)
        {
            P2Kalkan.SetActive(true);
            P2Can.SetActive(true);
        }
        else if (P2Health == 1)
        {
            P2Kalkan.SetActive(false);
            P2Can.SetActive(true);
        }
        else if (P2Health == 0)
        {
            P2Kalkan.SetActive(false);
            P2Can.SetActive(false);
            // game over panel
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
            P1Health--;
            // veya Invoke("BallController",2);
        }
        if (other.gameObject.CompareTag("Sag"))
        {
            Scoreoyuncu1++;
            RBtop.position = new Vector2(0, 0);
            RBtop.velocity = new Vector2(0, 0);
            isScore = true;
            P2Health--;
            // veya Invoke("BallController",2);
        }
        
        
    }
    
    
}
