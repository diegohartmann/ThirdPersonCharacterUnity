using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ThirdPersonChar : MonoBehaviour{

    [SerializeField] private Transform cam = null;
    [SerializeField] private GameObject pausePanel = null;

    private ThirdPersonCharReferences refs;
    private ThirdPersonCharUpdate updater;
    [SerializeField] private ThirdPersonCharStatus status = null;


    // private void OnEnable() {
    // }
    // private void OnDisable() {
    // }
    // private void OnDestroy() {
    // }

    private void Awake() {
        DestroyOtherCameras();
        refs = new ThirdPersonCharReferences(
            new ThirdPersonCharInputs(),
            getRb(),
            cam,
            this.transform,
            status,
            pausePanel
        );
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
        refs.update.Updater();
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