using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadParent : MonoBehaviour
{
    Rigidbody2D rb2d;
    protected Vector2 direction = Vector2.zero;
    [SerializeField] float speed = 10f;
    
    private void Awake() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    protected void Move(){
        rb2d.velocity = direction * speed;
    }
}
