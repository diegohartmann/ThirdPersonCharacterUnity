using UnityEngine;

public struct ThirdPersonCharPause 
{
    private ThirdPersonChar tpChar;
    private bool paused;
    public ThirdPersonCharPause(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        paused = false;
        SetPaused(false);
    }
    public void Updater(){
        if(tpChar.GetInputs().PauseInput()){
            PauseToggle();
        }
    }
    private void PauseToggle(){
        SetPaused(!paused);
    }
    public void SetPaused(bool _paused){
        paused = _paused;
        tpChar.GetPausePanel().SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }
    public bool IsPaused(){
        return paused;
    }
}
