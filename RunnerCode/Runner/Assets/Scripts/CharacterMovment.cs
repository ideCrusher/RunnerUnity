using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMovment : MonoBehaviour
{
    private Rigidbody2D _RB = new Rigidbody2D();
    private Vector2 _startPosition;
    private Text _ScoreText;
    private Text _CoinText;
    private float[] _Velosity = {250f,300f,350f,400f,450f,500f};
    private int _Start = 0,_CoinCounter = 0;
    private int _coef = 1;
    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _coef = (int)(_Start/10/5);
        InvokeRepeating("Score",0.3f,0.3f);
        _ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        _CoinText = GameObject.Find("CoinScore").GetComponent<Text>();
    }
    void Update()
    {        
        _RB.velocity = new Vector2(1 * 250* Time.fixedDeltaTime, _RB.velocity.y);
        
        if(Input.GetKey(KeyCode.Space))
        {
            _RB.AddForce(new Vector2(0, 1 * 800f * Time.fixedDeltaTime));
            _RB.mass = 0;     
        }
        _RB.mass = 1;       
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Traps"))
        {
            Saves();
            SceneManager.LoadScene(1);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {   
            _CoinCounter +=1;
            _CoinText.text = _CoinCounter.ToString();  
            Destroy(other.gameObject);
        }
    }
    void Score()
    {      
        _Start+=1;
        _ScoreText.text = _Start.ToString();
    }
    void Saves()
    {
         if(Convert.ToInt32(_ScoreText.text) > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", Convert.ToInt32(_ScoreText.text));
            }
            int Coin = PlayerPrefs.GetInt("CoinsScore");
            Coin = Coin + Convert.ToInt32(_CoinText.text);
            PlayerPrefs.SetInt("CoinsScore",Coin);   
    }
}
