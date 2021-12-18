using UnityEngine;

public struct ThirdPersonCharPause 
{
    private ThirdPersonCharReferences refs;
    [HideInInspector] public bool paused;
    public ThirdPersonCharPause(ThirdPersonCharReferences _refs){
        refs = _refs;
        paused = false;
    }
    public void Updater(){
        if(refs.inputs.PauseInput()){
            paused = !paused;
            refs.pausePanel.SetActive(paused);
            Time.timeScale = paused ? 0 : 1;
        }
    }
}
