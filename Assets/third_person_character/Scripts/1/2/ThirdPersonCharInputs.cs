using UnityEngine;

public struct ThirdPersonCharInputs{
    public float HorizontalInput(){return Input.GetAxisRaw("Horizontal");}
    public float VerticalInput(){return Input.GetAxisRaw("Vertical");}
    public bool JumpInput(){return Input.GetKeyDown(KeyCode.Space);}
    public bool RunInput(){return Input.GetKey(KeyCode.LeftShift);}
    public bool SlowInput(){return Input.GetKey(KeyCode.LeftControl);}
    public bool IsGroundMoving(){return (HorizontalInput()!=0) || (VerticalInput()!=0);}
    public bool PauseInput(){return Input.GetKeyDown(KeyCode.Escape);}
}
