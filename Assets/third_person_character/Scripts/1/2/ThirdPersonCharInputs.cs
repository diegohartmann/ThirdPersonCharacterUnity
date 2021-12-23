using UnityEngine;

public struct ThirdPersonCharInputs{
    public float HorizontalInput() => Input.GetAxisRaw("Horizontal");
    public float VerticalInput() => Input.GetAxisRaw("Vertical");
    public bool JumpInput() => Input.GetKeyDown(KeyCode.Space);
    public bool JumpInputRelease() => Input.GetKeyUp(KeyCode.Space);
    public bool JumpInputHold() => Input.GetKey(KeyCode.Space);
    public bool RunInput() => Input.GetKey(KeyCode.LeftShift);
    public bool SlowInput() => Input.GetKey(KeyCode.LeftControl);
    public bool IsGroundMoving() => (HorizontalInput() != 0) || (VerticalInput() != 0);
    public bool PauseInput() => Input.GetKeyDown(KeyCode.Escape);
}
