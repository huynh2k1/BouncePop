using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rb2D;
    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.CompareTag("Wall"))
        //{
        //    if(_rb2D.gravityScale <= 1f)
        //    {
        //        _rb2D.gravityScale += 0.2f;
        //    }
        //}
        if(collision.gameObject.CompareTag("bound"))
        {
            _rb2D.gravityScale = 0f;
        }
    }
}
