using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonChar : MonoBehaviour
{
    [Header("CHARACTER'S BODY")] [SerializeField] private Collider mainCenterColl = null; public Collider GetMainCenterColl() => this.mainCenterColl;
    [Header("CAM WITH 'CAMERA' COMPONENT")] [SerializeField] private  Transform cam = null; public Transform GetCam() => this.cam;
    [Header("INSIDE 'PLAYER UI'")] [SerializeField] private  GameObject pausePanel = null; public GameObject GetPausePanel() => this.pausePanel;
    [Header("CHARACTER'S BACKPACK")] [SerializeField] private Transform backPackTransform = null; public Transform GetBackPackTransform() => this.backPackTransform;
    [SerializeField] private  ThirdPersonCharBackPackData backPackData = null; public ThirdPersonCharBackPackData GetBackPackData() => this.backPackData;
    [Header("CHARACTER'S STATUS")] [SerializeField] private ThirdPersonCharStatus status = null; public ThirdPersonCharStatus GetCharStatus() => this.status;
    private ThirdPersonCharWalk walk; public ThirdPersonCharWalk GetWalk() => this.walk;
    private ThirdPersonCharJump jump; public ThirdPersonCharJump GetJump() => this.jump;
    private ThirdPersonCharBackPack backPack; public ThirdPersonCharBackPack GetBackPack() => this.backPack;
    private ThirdPersonCharUpdate updater; public ThirdPersonCharUpdate GetUpdater() => this.updater;
    private ThirdPersonCharInputs inputs; public ThirdPersonCharInputs GetInputs() => this.inputs;
    private ThirdPersonCharPause pause; public ThirdPersonCharPause GetPause() => this.pause;
    private Rigidbody rb; public Rigidbody GetRB() => this.rb;
    private Transform charTransform; public Transform GetCharTransform() => this.charTransform;
    public Vector3 GetCharPosition() => this.charTransform.position;

    // private void OnEnable() {
    // }
    // private void OnDisable() {
    // }
    // private void OnDestroy() {
    // }

    private void Awake() {
        charTransform = this.transform;
        walk = new ThirdPersonCharWalk(this);
        jump = new ThirdPersonCharJump(this);
        updater = new ThirdPersonCharUpdate(this);
        inputs = new ThirdPersonCharInputs();
        pause = new ThirdPersonCharPause(this);
        backPack = new ThirdPersonCharBackPack(this);
        rb = CreateNewRB();
        DestroyOtherCameras();
    }
    public void ResumeGameButton(){
        pause.TogglePause();
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
        Rigidbody newRB = ConfiguredRigidBody(GetComponent<Rigidbody>());
        return newRB;
    }

    private Rigidbody ConfiguredRigidBody(Rigidbody _rb){
        _rb.constraints = 
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ ;
        
        _rb.mass = status.mass;
        _rb.drag = status.drag;
        _rb.angularDrag = status.angularDrag;
        _rb.useGravity = status.useGravity;
        _rb.isKinematic = status.isKinematic;
        _rb.interpolation = status.interpolate;

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