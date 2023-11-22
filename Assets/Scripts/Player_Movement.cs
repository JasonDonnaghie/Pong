using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movement : MonoBehaviour
{   //Check if Player is Ai
    public bool isAI;
    //Speed the Players will move at
    public float playerSpeed;
    public float aiSpeed;
    //Key to go up and down - can change
    public KeyCode moveUp;
    public KeyCode moveDown;
    Rigidbody2D rb;
    //ball so Ai can see where it is and move
    public GameObject ball;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (isAI){
            AiMovement();
        }else{
            PlayerMovement();
        }
    }

    void PlayerMovement(){

        var vel = rb.velocity;

        if (Input.GetKey(moveUp)){
            vel.y = playerSpeed;
        }else if (Input.GetKey(moveDown)){
            vel.y = -playerSpeed;
        }else{
            vel.y = 0;
        }

        rb.velocity = vel;

    }

    void AiMovement(){

        var ballY = ball.transform.position.y;
        var vel = rb.velocity;

        if (ballY > transform.position.y + 0.4f){
            vel.y = aiSpeed;
        }else if(ballY < transform.position.y - 0.4f){
            vel.y = - aiSpeed;
        }else{
            vel.y = 0;
        }

        rb.velocity = vel;


    }
}
