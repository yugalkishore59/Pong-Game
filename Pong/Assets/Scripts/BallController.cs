using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed=10f;

    private void Awake() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start() {
        Toss();
    }

    void Toss(){
        transform.position = Vector3.zero;
        float x = Random.value>0.5?1:-1;
        float y = Random.Range(-0.5f,0.5f);
        rb2d.AddForce(new Vector2(x,0)*speed);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Pad"){
            AddRandomForce();
        }
    }

    void AddRandomForce(){
        float angle = 0.1f;
        float x = rb2d.velocity.x;
        float y = rb2d.velocity.y;
        rb2d.velocity = new Vector2((x*Mathf.Cos(angle) - y*Mathf.Sin(angle)),(x*Mathf.Sin(angle) + y*Mathf.Cos(angle)));
    }
}
