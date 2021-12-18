using UnityEngine;

public class ThirdPersonCharReferences
{
    public ThirdPersonCharController controller;
    public ThirdPersonCharInputs inputs;
    public ThirdPersonCharStatus status;
    public ThirdPersonCharPause pause;
    public Rigidbody rb;
    public Transform cam;
    public Transform charTransform;
    public GameObject pausePanel;
    public ThirdPersonCharUpdate update;
    public ThirdPersonCharReferences(ThirdPersonCharInputs _inputs, Rigidbody _rb, Transform _cam, Transform _charTransform, ThirdPersonCharStatus _status, GameObject _pausePanel){
        inputs = _inputs;
        rb = _rb;
        cam = _cam;
        charTransform = _charTransform;
        status = _status;
        pausePanel = _pausePanel;
        ParameterIndependent();
    }
    private void ParameterIndependent(){
        controller = new ThirdPersonCharController(this);
        pause = new ThirdPersonCharPause(this);
        update = new ThirdPersonCharUpdate(this);
    }
}
