using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMovment : MonoBehaviour
{
    private Rigidbody2D _RB = new Rigidbody2D();
    private Vector2 _startPosition;
    public Text ScoreText;
    public Text CoinText;
    private float[] _Velosity = {250f,300f,350f,400f,450f,500f};
    private int _Start = 0,_CoinCounter = 0;
    private int _coef = 1;
    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _coef = (int)(_Start/10/5);
    }
    void Update()
    {        
        
        _RB.velocity = new Vector2(1 * 250* Time.fixedDeltaTime, _RB.velocity.y);
        
        if(Input.GetKey(KeyCode.Space))
        {
            _RB.AddForce(new Vector2(0, 1 * 600f * Time.fixedDeltaTime));
            _RB.mass = 0;     
        }
        _RB.mass = 1;
        InvokeRepeating("Score",100,0);
        
    }
    void FixedUpdate()
    {
        Score();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Traps"))
        {
            SceneManager.LoadScene(1);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {   
            _CoinCounter +=1;
            CoinText.text = _CoinCounter.ToString();  
            Destroy(other.gameObject);
        }
    }
    void Score()
    {      
        _Start+=1;
        int d =_Start/25;
        ScoreText.text = d.ToString();
    }
    
}
