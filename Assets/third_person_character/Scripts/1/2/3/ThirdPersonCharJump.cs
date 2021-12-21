using UnityEngine;

public struct ThirdPersonCharJump
{
    private float jumpFuel;
    private ThirdPersonChar tpChar;
    public ThirdPersonCharJump(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        jumpFuel = 0;
    }
    public void Updater(){
        if (tpChar.status.jumpable){
            if (tpChar.inputs.JumpInput() && HasJumpFuel()){
                Jump();
                jumpFuel = 0;
                return;
            }
            if (jumpFuel < 1){
                jumpFuel += FrameIndependent(1);
            }
        }
    }
    private bool HasJumpFuel(){
        return jumpFuel >= 1;
    }
    private void Jump(){
        tpChar.rb.AddForce(Vector3.up * (FrameIndependent(tpChar.status.jumpForce, 5000)), ForceMode.Acceleration);
    }
    private float FrameIndependent(float _mult1, float _mult2 = 1){
        return _mult1 * _mult2 * Time.deltaTime;
    }
}
