using UnityEngine;

[CreateAssetMenu(fileName="Status", menuName="ThirdPersonCharObjs/ThirdPersonCharStatus", order=1)]
public class ThirdPersonCharStatus : ScriptableObject{

    [Header("RIGIDBODY")]
    [Range(000.1f,100)]
    public float mass = 1;
    public float drag = 0;
    public float angularDrag = 0.05f;
    public bool useGravity = true;
    public bool isKinematic = false;
    public RigidbodyInterpolation interpolate = RigidbodyInterpolation.Interpolate;

    [Header("WALK")]
    
    [Range(0,5)]
    public float turnSmoothTime = 1.2f;
    public int slowSpeed = 5;
    public int walkSpeed = 10;
    public int runSpeed = 30;
    public bool inclinatesForwardOnRun = true;
    public int rotationSpeed = 30;
    
    [Header("JUMP")]
    public bool jumpable = true;
    [Range(1,20)]
    public float jumpForce = 5;
    public bool holdToJumpHigher = true;
    public float higherJumpForce = 7;
    public float speedToChargeHigherJumpForce = 2;
}
