using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonChar : MonoBehaviour
{
    [Header("CAM WITH 'CAMERA' COMPONENT")] [SerializeField] private  Transform cam = null;
    public Transform GetCam() { return this.cam; }
    [Header("INSIDE 'PLAYER UI'")] [SerializeField] private  GameObject pausePanel = null;
    public GameObject GetPausePanel() { return this.pausePanel; }
    [Header("CHARACTER'S BACKPACK")] [SerializeField] private Transform backPackTransform = null;
    public Transform GetBackPackTransform() { return this.backPackTransform; }
    [SerializeField] private  ThirdPersonCharBackPackData backPackData = null;
    public ThirdPersonCharBackPackData GetBackPackData() { return this.backPackData; }
    [Header("CHARACTER'S STATUS")] [SerializeField] private ThirdPersonCharStatus status = null;
    public ThirdPersonCharStatus GetCharStatus() { return this.status; }
    private ThirdPersonCharWalk walk;
    public ThirdPersonCharWalk GetWalk() { return this.walk; }
    private ThirdPersonCharJump jump;
    public ThirdPersonCharJump GetJump() { return this.jump; }
    private ThirdPersonCharBackPack backPack;
    public ThirdPersonCharBackPack GetBackPack() { return this.backPack; }
    private ThirdPersonCharUpdate updater;
    public ThirdPersonCharUpdate GetUpdater(){return this.updater;}
    private ThirdPersonCharInputs inputs;
    public ThirdPersonCharInputs GetInputs(){return this.inputs;}
    private ThirdPersonCharPause pause;
    public ThirdPersonCharPause GetPause(){return this.pause;}
    private Rigidbody rb;
    public Rigidbody GetRB() { return this.rb; }
    private Transform charTransform;
    public Transform GetCharTransform(){ return this.charTransform; }

    // private void OnEnable() {
    // }
    // private void OnDisable() {
    // }
    // private void OnDestroy() {
    // }

    private void Awake() {
        rb = CreateNewRB();
        charTransform = this.transform;
        walk = new ThirdPersonCharWalk(this);
        jump = new ThirdPersonCharJump(this);
        updater = new ThirdPersonCharUpdate(this);
        inputs = new ThirdPersonCharInputs();
        pause = new ThirdPersonCharPause(this);
        backPack = new ThirdPersonCharBackPack(this);
    }
    public void ResumeGameButton(){
        pause.SetPaused(false);
    }
    
    private void DestroyOtherCameras(){
        Camera[] _cams = GameObject.FindObjectsOfType<Camera>();
        int destroyed = 0;
        foreach (var _cam in _cams){
            if (_cam.gameObject != cam.gameObject){
                Destroy(_cam.gameObject);
                destroyed++;
            }
        }
        if(destroyed>0){
            Debug.LogWarning("Cameras destruídas: " + destroyed);
        }
    }
    private Rigidbody CreateNewRB(){
        if(GetComponent<Rigidbody>() == null){
            gameObject.AddComponent<Rigidbody>();
        }
        Rigidbody thisRB = GetComponent<Rigidbody>();
        thisRB = rbConstrains(thisRB);
        thisRB = rbInterpolate(thisRB);
        thisRB = rbCollision(thisRB);
        return thisRB;
    }
    private Rigidbody rbConstrains(Rigidbody _rb){
        _rb.constraints = 
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ ;
        return _rb;
    }
    private Rigidbody rbInterpolate(Rigidbody _rb){
        // _rb.interpolate = Interpolate.interpolate
        return _rb;
    }
    private Rigidbody rbCollision(Rigidbody _rb){
        // rb.colissionDetect = Continuous dymanic
        return _rb;
    }
    
    private void Update() {
        updater.Updater();
    }

    // private void OnCollisionEnter(Collision collision){
        
    // }
     
    // private void OnCollisionExit(Collision collision){
        
    // }

    // private void OnTriggerEnter(Collider other){
        
    // }

    // private void OnTriggerExit(Collider other){

    // }
}