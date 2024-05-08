using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunHareket : MonoBehaviour
{
    public Rigidbody2D RBoyuncu1, RBoyuncu2;
    public float harekethizi = 10f;
    void Start()
    {
        RBoyuncu1 = GameObject.Find("SolOyuncu").GetComponent<Rigidbody2D>();
        RBoyuncu2 = GameObject.Find("SagOyuncu").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RBoyuncu1.velocity = Vector2.up * Input.GetAxisRaw("Vertical")* harekethizi;
        RBoyuncu2.velocity = Vector2.up * Input.GetAxisRaw("Vertical2")* harekethizi;
    }
}
