using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    private Rigidbody2D _RB = new Rigidbody2D();
    private const float _MultiplaySpeed = 230;
    private float _AxisRotationX = 0f;
    private bool _isJump = false;
    private bool _isGround = false;
    private bool _FacingRight = false;

    
    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();


    }

    void Update()
    {        
        _AxisRotationX = Input.GetAxis("Horizontal");

        
        if(Input.GetKey(KeyCode.Space))
        {
            _RB.velocity = new Vector2(_RB.velocity.x, 1 * _MultiplaySpeed * Time.fixedDeltaTime); 
        }

    }

    void FixedUpdate()
    {
        
        _RB.velocity = new Vector2(_AxisRotationX * _MultiplaySpeed * Time.fixedDeltaTime, _RB.velocity.y);
        if(_AxisRotationX < 0f && !_FacingRight)
        {
            Flip();
        }   
        else if(_AxisRotationX > 0f && _FacingRight)
        {
            Flip();
        }      
        if(_isJump)
        {           
            
            _isJump = false;                
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _isGround = true;        
        }    

        
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            _isGround = false;        
        }  
    }



    void Flip()
    {
        _FacingRight = !_FacingRight;
        Vector3 playrScale = transform.localScale;
        playrScale.x = playrScale.x * (-1f);;
        transform.localScale = playrScale;
    }


}
