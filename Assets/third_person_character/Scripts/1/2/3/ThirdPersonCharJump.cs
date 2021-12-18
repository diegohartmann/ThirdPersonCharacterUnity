using UnityEngine;

public struct ThirdPersonCharJump
{
    private float jumpFuel;
    private ThirdPersonCharReferences refs;
    public ThirdPersonCharJump(ThirdPersonCharReferences _refs){
        refs = _refs;
        jumpFuel = 0;
    }
    public void Updater(){
        if (refs.status.jumpable){
            if (refs.inputs.JumpInput() && HasJumpFuel()){
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
        refs.rb.AddForce(Vector3.up * (FrameIndependent(refs.status.jumpForce, 5000)), ForceMode.Acceleration);
    }
    private float FrameIndependent(float _mult1, float _mult2 = 1){
        return _mult1 * _mult2 * Time.deltaTime;
    }
}
