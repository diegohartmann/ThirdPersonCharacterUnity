using UnityEngine;

public struct ThirdPersonCharUpdate{
    private ThirdPersonCharReferences refs;
    public ThirdPersonCharUpdate(ThirdPersonCharReferences _refs){
        refs = _refs;
    }
    public void Updater(){
        GeralUpdater();
        GameplayUpdater();
    }
    private void GeralUpdater(){
        refs.pause.Updater();
    }
    private void GameplayUpdater(){
        if (!refs.pause.paused) { 
            refs.controller.Updater();
        }
    }
}