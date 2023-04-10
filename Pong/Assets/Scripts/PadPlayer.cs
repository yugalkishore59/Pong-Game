using UnityEngine;

public class PadPlayer : PadParent
{
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate() {
        Move();
    }

    void GetInput(){
        if(Input.GetKey("w")){
            direction = Vector2.up;
        }else if(Input.GetKey("s")){
            direction = Vector2.down;
        }else{
            direction = Vector2.zero;
        }
    }
}
