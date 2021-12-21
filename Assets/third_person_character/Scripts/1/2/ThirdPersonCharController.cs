using UnityEngine;
public struct ThirdPersonCharController{
    private ThirdPersonCharWalk walk;
    private ThirdPersonCharJump jump;

    public ThirdPersonCharController(ThirdPersonChar _tpChar){
        jump = new ThirdPersonCharJump(_tpChar);
        walk = new ThirdPersonCharWalk(_tpChar);
    }
    public void Updater(){
        walk.Updater();
        jump.Updater();
    }
}
