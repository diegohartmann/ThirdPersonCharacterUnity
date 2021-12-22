using UnityEngine;

public struct ThirdPersonCharPause {
    private ThirdPersonChar tpChar;
    private bool paused;
    public ThirdPersonCharPause(ThirdPersonChar _tpChar){
        tpChar = _tpChar;
        paused = false;
        ApplyPauseStatus();
    }
    public void Updater(){
        PauseCheck();
    }
    private void PauseCheck(){
        if(tpChar.GetInputs().PauseInput()){
            TogglePause();
        }
    }
    public void TogglePause(){
        paused = !paused;
        ApplyPauseStatus();
    }
    private void ApplyPauseStatus(){
        tpChar.GetPausePanel().SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }
    public bool IsPaused(){
        return paused;
    }
}
