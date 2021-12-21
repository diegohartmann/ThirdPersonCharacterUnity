using UnityEngine;

public struct ThirdPersonCharWalk{

    private float speed;
    private float turnSmoothVelocity;
    private float xRot;
    private const int xRotMax = 20;
    private const int xRotSpeed = 100;
    private float currAngle;
    private ThirdPersonChar tpChar;
    public ThirdPersonCharWalk(ThirdPersonChar _tpChar){
        xRot = 0;
        currAngle = 0;
        turnSmoothVelocity = 0;
        speed=0;
        tpChar = _tpChar;
    }
    
    public void Updater(){
        SpeedCheck();
        MovementCheck();
    }
    private void SpeedCheck(){
        if (tpChar.inputs.RunInput()){
            Run();
            return;
        }
        TryToInclinateBody(false);
        if (tpChar.inputs.SlowInput()){
            Slow();
            return;
        }
        Walk();
    }
    
    private Vector3 Direction(){
        return new Vector3 (tpChar.inputs.HorizontalInput(), 0, tpChar.inputs.VerticalInput()).normalized;
    }
    private Vector3 RBVerticalVel(){
        return new Vector3(0, tpChar.rb.velocity.y, 0);
    }
    private float TargetAngle(){
        return (Mathf.Atan2( Direction().x, Direction().z ) * Mathf.Rad2Deg) + CamEulerY();
    }
    private Vector3 RBVel(Vector3 _moveDir, int _speedMult){
        return (_moveDir.normalized * speed * _speedMult * Time.deltaTime);
    }
    private float CharEulerY(){
        return tpChar.charTransform.eulerAngles.y;
    }
    private float CamEulerY(){
        return tpChar.cam.eulerAngles.y;
    }
    private void MovementCheck(){
        if(tpChar.inputs.IsGroundMoving()){
            currAngle = CharEulerY();
        }
        _PlayerMovement();
        PlayerRotation();
    }
    private void PlayerRotation(){
        tpChar.charTransform.rotation = Quaternion.Euler(xRot, currAngle, 0);
    }
    private Vector3 MoveDirection(){
        return Quaternion.Euler(0, TargetAngle(), 0) * (Vector3.forward);
    }
    private void _PlayerMovement(){
        if (Direction().magnitude >= 0.1f){
            currAngle = Mathf.SmoothDampAngle(CharEulerY(), TargetAngle(), ref turnSmoothVelocity, tpChar.status.turnSmoothTime * Time.deltaTime * 10);
            SetRigidbodyVelocity(RBVel(MoveDirection(), 50) + RBVerticalVel());
            return;
        }
        SetRigidbodyVelocity(RBVerticalVel());
    }
    private void SetRigidbodyVelocity(Vector3 _vel){
        if(tpChar.rb.velocity != _vel){
            tpChar.rb.velocity = _vel;
        }
    }
    private void Run(){
        speed = tpChar.status.runSpeed;
        TryToInclinateBody(true);
    }
    private void Walk(){
        speed = tpChar.status.walkSpeed;
    }
    private void Slow(){
        speed = tpChar.status.slowSpeed;
    }
    private void TryToInclinateBody(bool _forwards){
        if(tpChar.status.inclinatesForwardOnRun){
            if (_forwards){
                if (xRot < xRotMax){
                    xRot += Time.deltaTime * xRotSpeed;
                }
                return;
            }
            if (xRot > 0){
                xRot -= Time.deltaTime * xRotSpeed;
            }
        }
    }
  
    // private void RotateTronco(){
    //     if(tpChar.tronco){
    //         tpChar.tronco.Rotate(speed*50 * Time.deltaTime, 0, 0);
    //     }
    // }
}
