using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharFaceFoward : MonoBehaviour
{
    [SerializeField] private Transform head = null;
    [SerializeField] private Transform cam  = null;
    [SerializeField] private Transform lookTar= null;
    [SerializeField] bool turnHeadDefault = true;

    const float normalSpeed = 0.6f;
    const float aimSpeed = 0.1f;

    [SerializeField] private KeyCode[] keyCodes = null;

    private void Start(){
        Shoot(false);
    }
    
    private void Update(){
        if (Time.timeScale>0){
            SwapLaserCheck();
            Shoot(LaserInput());
            if (AimInput()){
                _LookAt(head, cam, aimSpeed);
                return;
            }
            if (turnHeadDefault){
                _LookAt(head, cam, normalSpeed);
                return;
            }
            _LookAt(head, lookTar, aimSpeed);
            return;
        }
    }

    private bool AimInput(){
        return Input.GetMouseButton(1);
    }

    private bool LaserInput(){
        return Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
    }
    
    private void _LookAt(Transform _looker, Transform _target, float _speed){
        Quaternion targetRotation  = Quaternion.LookRotation( _looker.position -_target.position );
        _looker.rotation = Quaternion.Slerp(_looker.rotation, targetRotation, Time.deltaTime / _speed);
    }

    private void Shoot(bool _b){
        Debug.Log("Shooting");
    }

    private void SwapLaserCheck(){
        for(int i = 0 ; i < keyCodes.Length; i ++ ){
            if(Input.GetKeyDown(keyCodes[i])){
                SwapShoot(i);
            }
        }
    }
    private void SwapShoot(int i){
        //
    }
}
