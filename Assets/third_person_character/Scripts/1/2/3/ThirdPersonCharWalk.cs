using UnityEngine;
public enum InclinationOnRun
{
    Forwards,
    Backwards
}
public struct ThirdPersonCharWalk{

    private float speed;
    private float turnSmoothVelocity;
    private float xRot;
    private const int xRotMax = 20;
    private const int xRotSpeed = 100;
    private float currAngle;
    private ThirdPersonCharReferences refs;
    public ThirdPersonCharWalk(ThirdPersonCharReferences _refs){
        xRot = 0;
        currAngle = 0;
        turnSmoothVelocity = 0;
        speed=0;
        refs = _refs;
    }
    
    public void Updater(){
        SpeedCheck();
        MovementCheck();
    }
    private void SpeedCheck(){
        if (refs.inputs.RunInput()){
            Run();
            return;
        }
        TryToInclinateBody(InclinationOnRun.Backwards);
        if (refs.inputs.SlowInput()){
            Slow();
            return;
        }
        Walk();
    }
    
    private Vector3 Direction(){
        return new Vector3 (refs.inputs.HorizontalInput(), 0, refs.inputs.VerticalInput()).normalized;
    }
    private Vector3 RBVerticalVel(){
        return new Vector3(0, refs.rb.velocity.y, 0);
    }
    private float TargetAngle(){
        return (Mathf.Atan2( Direction().x, Direction().z ) * Mathf.Rad2Deg) + CamEulerY();
    }
    private Vector3 RBVel(Vector3 _moveDir, int _speedMult){
        return (_moveDir.normalized * speed * _speedMult * Time.deltaTime);
    }
    private float CharEulerY(){
        return refs.charTransform.eulerAngles.y;
    }
    private float CamEulerY(){
        return refs.cam.eulerAngles.y;
    }
    private void MovementCheck(){
        if(refs.inputs.IsGroundMoving()){
            currAngle = CharEulerY();
        }
        _PlayerMovement();
        PlayerRotation();
    }
    private void PlayerRotation(){
        refs.charTransform.rotation = Quaternion.Euler(xRot, currAngle, 0);
    }
    private Vector3 MoveDirection(){
        return Quaternion.Euler(0, TargetAngle(), 0) * (Vector3.forward);
    }
    private void _PlayerMovement(){
        if (Direction().magnitude >= 0.1f){
            currAngle = Mathf.SmoothDampAngle(CharEulerY(), TargetAngle(), ref turnSmoothVelocity, refs.status.turnSmoothTime);
            SetRigidbodyVelocity(RBVel(MoveDirection(), 50) + RBVerticalVel());
            return;
        }
        SetRigidbodyVelocity(RBVerticalVel());
    }
    private void SetRigidbodyVelocity(Vector3 _vel){
        if(refs.rb.velocity != _vel){
            refs.rb.velocity = _vel;
        }
    }
    private void Run(){
        speed = refs.status.runSpeed;
        TryToInclinateBody(InclinationOnRun.Forwards);
    }
    private void Walk(){
        speed = refs.status.walkSpeed;
    }
    private void Slow(){
        speed = refs.status.slowSpeed;
    }
    private void TryToInclinateBody(InclinationOnRun _inclinationType){
        if(refs.status.inclinatesForwardOnRun){
            switch (_inclinationType){
                case InclinationOnRun.Forwards:
                if (xRot < xRotMax){
                    xRot += Time.deltaTime * xRotSpeed;
                }
                break;
                case InclinationOnRun.Backwards:
                    if (xRot > 0){
                        xRot -= Time.deltaTime * xRotSpeed;
                    }
                break;
            }
        }
    }
  
    // private void RotateTronco(){
    //     if(refs.tronco){
    //         refs.tronco.Rotate(speed*50 * Time.deltaTime, 0, 0);
    //     }
    // }
}
