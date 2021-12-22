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
        if (tpChar.GetCharStatus().jumpable){
            if(HasJumpFuel()){
                if (tpChar.GetInputs().JumpInput()){
                    Jump();
                    return;
                }
                return;
            }
            RefillJumpFuel(2);
        }
    }
    private void RefillJumpFuel(float _speed = 1){
        jumpFuel += Time.deltaTime * _speed;
    }
    private bool HasJumpFuel(){
        return !(jumpFuel < 1);
    }
    private void Jump(){
        tpChar.GetRB().AddForce(Vector3.up * (tpChar.GetCharStatus().jumpForce *Time.deltaTime* 5000), ForceMode.Acceleration);
        jumpFuel = 0;
    }
}
