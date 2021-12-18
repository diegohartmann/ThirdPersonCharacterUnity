using UnityEngine;
public struct ThirdPersonCharController{
    private ThirdPersonCharReferences refs;
    private ThirdPersonCharWalk walk;
    private ThirdPersonCharJump jump;

    public ThirdPersonCharController(ThirdPersonCharReferences _refs){
        refs = _refs;
        jump = new ThirdPersonCharJump(refs);
        walk = new ThirdPersonCharWalk(refs);
    }
    public void Updater(){
        // if( ThirdPersonCharPlayState.state == PlayState.Running ){
            walk.Updater();
            jump.Updater();
        // }
    }
}
