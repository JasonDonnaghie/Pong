using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Movement : MonoBehaviour
{
    //speed of the ball
    public float speed;
    // see who scored last goal: True = Player : False = AI 
    private bool recentGoal = true;
    //Player Score
    public Text playerScore;
    private int pScore = 0;
    //Ai Score
    public Text AiScore;
    private int aScore = 0;
    //Rigidbody of Ball
    Rigidbody2D rb;

    void Start()
    {   //Call startBall and wait 2 seconds to run it
        Invoke("startBall",2f);
    }

    void startBall(){
        //set Rigidbody 
        rb = GetComponent<Rigidbody2D>();

        //Get a random Y so ball doesn't shoot straight
        var randY = Random.Range(-7.0f,7.0f);
        if (recentGoal){
            Vector2 startSpeed = new Vector2(speed,randY);
            rb.velocity = startSpeed;
        }else{
            Vector2 startSpeed = new Vector2(-speed,randY);
            rb.velocity = startSpeed;
        }
    }

    void resetBall(){
        //set Rigidbody
        rb = GetComponent<Rigidbody2D>();

        //reset Ball Position and Velocity
        rb.position = new Vector2(0,0);
        rb.velocity = new Vector2(0,0);

        //Call startBall and wait 2 seconds to run it
        Invoke("startBall",2f);

    }

    private void OnCollisionEnter2D(Collision2D collision){
        //See if the Player or Ai missed the ball and let it hit their back wall/goal
        if (collision.collider.name == "Right Wall"){
            pScore++;
            playerScore.text = pScore.ToString();
            recentGoal = true;
            resetBall();
        }else if(collision.collider.name == "Left Wall"){
            aScore++;
            AiScore.text = aScore.ToString();
            recentGoal = false;
            resetBall();
        }
        
        
    }
}
