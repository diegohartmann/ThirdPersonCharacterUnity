using UnityEngine;

public struct ThirdPersonCharUpdate{
    private ThirdPersonChar tpChar;
    public ThirdPersonCharUpdate(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
    }
    public void Updater(){
        GeralUpdater();
        GameplayUpdater();
    }
    private void GeralUpdater(){
        tpChar.GetPause().Updater();
    }
    private void GameplayUpdater(){
        if (!tpChar.GetPause().IsPaused()) { 
            tpChar.GetJump().Updater();
            tpChar.GetWalk().Updater();
            tpChar.GetBackPack().Updater();
        }
    }
}