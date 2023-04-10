using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed=10f;
    bool isPaused= false;
    [SerializeField]TextMeshProUGUI leftScore;
    [SerializeField]TextMeshProUGUI rightScore;
    [SerializeField]TextMeshProUGUI leftResult;
    [SerializeField]TextMeshProUGUI rightResult;
    int score;
    bool isFirstToss = true;

    private void Awake() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start() {
        Toss();
    }

    private void Update() {
        if(isPaused){
            transform.position = Vector3.zero;
            rb2d.velocity = Vector2.zero;
        }
        if(isPaused && Input.GetMouseButtonDown(0)){
            rightResult.text = "";
            leftResult.text = "";
            rightScore.text ="0";
            leftScore.text ="0";

            isPaused = false;
            Toss();
        }
    }

    void Toss(){
        isFirstToss = true;
        transform.position = Vector3.zero;
        float x = Random.value>0.5?1:-1;
        float y = Random.Range(-0.5f,0.5f);
        rb2d.velocity = new Vector2(x,y)*(speed*0.5f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Pad"){
            if(isFirstToss){
                isFirstToss=false;
                rb2d.velocity *= 2;
            }
            //AddRandomForce();
            AddPadForce(other.gameObject.GetComponent<Rigidbody2D>());
        }else if(other.gameObject.tag == "LeftWall"){
            score = int.Parse(rightScore.text);
            score++;
            rightScore.text = score.ToString();
            if(score>10){
                isPaused = true;
                rightResult.text = "Winner";
                leftResult.text = "Loser";
            }else{
                Toss();
            }
        }else if(other.gameObject.tag == "RightWall"){
            score = int.Parse(leftScore.text);
            score++;
            leftScore.text = score.ToString();
            if(score>10){
                isPaused = true;
                rightResult.text = "Loser";
                leftResult.text = "Winner";
            }else{
                Toss();
            }
        }
    }

    void AddPadForce(Rigidbody2D pad){
        float angle = 0;
        if(pad.velocity.y>0){
            angle=Random.Range(0,5f) * 0.1f;
        }else {
            angle=Random.Range(-5f,0) * 0.1f;
        }
        float x = rb2d.velocity.x;
        float y = rb2d.velocity.y;
        Vector2 newVelocity = new Vector2((x*Mathf.Cos(angle) - y*Mathf.Sin(angle)),(x*Mathf.Sin(angle) + y*Mathf.Cos(angle)));
        if(Mathf.Abs(newVelocity.y / newVelocity.x) < 2.5f){
            rb2d.velocity = newVelocity;
        }else{
            if(newVelocity.x>0){
                rb2d.velocity = Vector2.right * speed;
            }else{
                rb2d.velocity = Vector2.left * speed;
            }
        }
    }

    void AddRandomForce(){
        float angle = Random.Range(-5f,5f) * 0.1f;
        float x = rb2d.velocity.x;
        float y = rb2d.velocity.y;
        Vector2 newVelocity = new Vector2((x*Mathf.Cos(angle) - y*Mathf.Sin(angle)),(x*Mathf.Sin(angle) + y*Mathf.Cos(angle)));
        if(Mathf.Abs(newVelocity.y / newVelocity.x) < 2.5f){
            rb2d.velocity = newVelocity;
        }else{
            if(newVelocity.x>0){
                rb2d.velocity = Vector2.right * speed;
            }else{
                rb2d.velocity = Vector2.left * speed;
            }
        }
    }
}
