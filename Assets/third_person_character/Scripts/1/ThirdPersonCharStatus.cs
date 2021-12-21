using UnityEngine;

[CreateAssetMenu(fileName="Status", menuName="ThirdPersonCharObjs/ThirdPersonCharStatus", order=1)]
public class ThirdPersonCharStatus : ScriptableObject{
    
    [Header("Walk")]
    
    [Range(0,5)]
    public float turnSmoothTime = 1.2f;
    public int slowSpeed = 5;
    public int walkSpeed = 10;
    public int runSpeed = 30;
    public bool inclinatesForwardOnRun = true;
    public int rotationSpeed = 30;
    
    [Header("Jump")]
    public bool jumpable = true;
    [Range(1,5)]
    public float jumpForce = 2;

}
