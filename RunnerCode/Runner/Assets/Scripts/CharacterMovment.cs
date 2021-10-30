using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class CharacterMovment : MonoBehaviour
{
    private Rigidbody2D _RB = new Rigidbody2D();
    private Vector2 _startPosition;
    public Text ScoreText;
    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    void Update()
    {        
        _RB.velocity = new Vector2(1 * 250 * Time.fixedDeltaTime, _RB.velocity.y); 
        if(Input.GetKey(KeyCode.Space))
        {
            _RB.AddForce(new Vector2(0, 2 * 500 * Time.fixedDeltaTime));       
        }
        Score();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Traps"))
        {
            SceneManager.LoadScene(0);
        }
    }

    void Score()
    {
        float Start = 0;
        if(transform.position.x > 0)
        {
            Start = (transform.position.x - Start);
            Start = (int) Start;
        }
        
        ScoreText.text = Start.ToString("0.");
    }
}
