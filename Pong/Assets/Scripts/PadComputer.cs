using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadComputer : PadParent
{
    [SerializeField] Rigidbody2D ball;

    private void Update() {
        SetDirection();
    }

    private void FixedUpdate() {
        Move();
    }

    void SetDirection(){
        if(ball.velocity.x<0){
            direction = Vector2.zero;
        }else if(ball.position.y < transform.position.y-2){
            direction = Vector2.down;
        }else if(ball.position.y > transform.position.y+2){
            direction = Vector2.up;
        }else{
            direction = Vector2.zero;
        }
    }
}
