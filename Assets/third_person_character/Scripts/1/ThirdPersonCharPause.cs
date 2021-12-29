using UnityEngine;

public class ThirdPersonCharPause {
    private ThirdPersonChar tpChar;
    private bool paused;
    public bool IsPaused() => this.paused;

    public ThirdPersonCharPause(ThirdPersonChar _tpChar){
        this.tpChar = _tpChar;
        ResumeGame();
    }
    public void Updater(){
        PauseCheck();
    }
    private void PauseCheck(){
        if(tpChar.GetInputs().PauseInput()){
            TogglePause();
        }
    }
    public void ResumeGame(){
        paused = false;
        ApplyPauseStatus(this.paused);
    }
    private void TogglePause(){
        paused = !paused;
        ApplyPauseStatus(this.paused);
    }
    private void ApplyPauseStatus(bool _paused){
        tpChar.GetPausePanel().SetActive( _paused);
        Time.timeScale = _paused ? 0 : 1;
        Cursor.visible = _paused;
    }
}
