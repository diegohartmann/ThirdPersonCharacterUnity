using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonChar : MonoBehaviour{

    [Header("CAM WITH 'CAMERA' COMPONENT")] public Transform cam = null;
    [Header("INSIDE 'PLAYER UI'")] public GameObject pausePanel = null;
    [Header("CHARACTER'S BACKPACK")]
    public Transform backpack = null;
    public int selectedBackPackItem = 0;
    public KeyCode clearHandInput = KeyCode.Alpha0;
    public KeyCode[] itemsSelectInputs = new KeyCode[] {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9
    };
    public List <int> gotItems = new List<int>();

    [Header("SCRIPTABLE OBJECT")] public ThirdPersonCharStatus status = null;
    [HideInInspector]public ThirdPersonCharWalk walk;
    [HideInInspector]public ThirdPersonCharJump jump;
    [HideInInspector]public ThirdPersonCharBackPack backPack;
    [HideInInspector]public ThirdPersonCharUpdate updater;
    [HideInInspector]public ThirdPersonCharInputs inputs;
    [HideInInspector]public ThirdPersonCharPause pause;
    [HideInInspector]public Rigidbody rb;
    [HideInInspector]public Transform charTransform;
    // [HideInInspector]public List <int> gotItems = new List<int>();


    // private void OnEnable() {
    // }
    // private void OnDisable() {
    // }
    // private void OnDestroy() {
    // }
    
    private void Awake() {
        rb = getRb();
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
    private Rigidbody getRb(){
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