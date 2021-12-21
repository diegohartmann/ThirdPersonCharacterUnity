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
        tpChar.pause.Updater();
    }
    private void GameplayUpdater(){
        if (!tpChar.pause.paused) { 
            tpChar.controller.Updater();
            tpChar.backPack.Updater();
        }
    }
}