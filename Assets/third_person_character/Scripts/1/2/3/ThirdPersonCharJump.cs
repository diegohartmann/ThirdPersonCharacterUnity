using UnityEngine;

public struct ThirdPersonCharJump
{
    private float distToGround;
    private ThirdPersonChar tpChar;
    public ThirdPersonCharJump(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        distToGround = _tpChar.GetMainCenterColl().bounds.extents.y;
    }
   
    public void Updater(){
       if (tpChar.GetCharStatus().jumpable){
            if(IsGrounded()){
                SimpleJumpCheck();
            }
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
