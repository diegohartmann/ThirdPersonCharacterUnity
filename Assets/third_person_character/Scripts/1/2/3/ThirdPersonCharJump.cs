using UnityEngine;

public struct ThirdPersonCharJump
{
    private float distToGround;
    private ThirdPersonChar tpChar;
    private float actualHigherJumpForce;
    public ThirdPersonCharJump(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        distToGround = _tpChar.GetMainCenterColl().bounds.extents.y;
        actualHigherJumpForce = tpChar.GetCharStatus().jumpForce;
    }
   
    public void Updater(){
       if (tpChar.GetCharStatus().jumpable){
            if(IsGrounded()){
                if(tpChar.GetCharStatus().holdToJumpHigher){
                    ChargedJumpCheck();
                    return;
                }
                SimpleJumpCheck();
            }
        }
    }
    private void ChargedJumpCheck(){
        if(tpChar.GetInputs().JumpInputHold()){
            if(actualHigherJumpForce > tpChar.GetCharStatus().higherJumpForce){
                actualHigherJumpForce = tpChar.GetCharStatus().higherJumpForce;
                return;
            }
            actualHigherJumpForce += Time.deltaTime * tpChar.GetCharStatus().speedToChargeHigherJumpForce;
            Debug.Log(actualHigherJumpForce);
        }
        if (tpChar.GetInputs().JumpInputRelease()){
            Jump(actualHigherJumpForce);
            actualHigherJumpForce = tpChar.GetCharStatus().jumpForce;
        }
    }
    private void SimpleJumpCheck(){
        if(tpChar.GetInputs().JumpInput()){
            Jump(tpChar.GetCharStatus().jumpForce);
        }
    }
    private bool IsGrounded(){
        return Physics.Raycast(tpChar.GetCharPosition(), - Vector3.up, distToGround + 0.1f);
    }
    private void Jump(float _force){
        tpChar.GetRB().AddForce(Vector3.up * (_force * Time.deltaTime * 150), ForceMode.Impulse);
    }
   
}
