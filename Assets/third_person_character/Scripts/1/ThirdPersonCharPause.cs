using UnityEngine;

public struct ThirdPersonCharPause 
{
    private ThirdPersonChar tpChar;
    [HideInInspector] public bool paused;
    public ThirdPersonCharPause(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        paused = false;
        SetPaused(false);
    }
    public void Updater(){
        if(tpChar.inputs.PauseInput()){
            PauseToggle();
        }
    }
    private void PauseToggle(){
        SetPaused(!paused);
    }
    public void SetPaused(bool _paused){
        paused = _paused;
        tpChar.pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }
}
