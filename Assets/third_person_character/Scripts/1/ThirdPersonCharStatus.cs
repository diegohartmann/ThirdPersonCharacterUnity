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
    
    [Range(0.1f,0.3f)]
    public float turnSmoothTime = 0.2f;
    public int slowSpeed = 2;
    public int walkSpeed = 4;
    public int runSpeed = 8;
    public bool inclinatesForwardOnRun = false;
    
    [Header("JUMP")]
    public bool jumpable = true;
    [Range(1,20)]
    public float jumpForce = 5;
}
