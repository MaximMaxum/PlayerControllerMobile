// SrtumDev
// YouTube https://www.youtube.com/channel/UCsAcfm0AVVZwLiJ3D451R3g/featured
// Discord https://discord.gg/GtzqG7pgNJ
// GitHub https://github.com/StrumDev

using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerMuvment : MonoBehaviour
{
    public float Speed = 5;
    public float JumpStrength = 2f;
    public GroundCheck GroundCheeck;
    public FloatingJoystick FloatingJoystick;

    private Rigidbody rig;
    
    private void Start() 
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float Ver = FloatingJoystick.Vertical;
        float Hor = FloatingJoystick.Horizontal; 

        transform.Translate(Hor * Speed * Time.deltaTime, 0, Ver * Speed * Time.deltaTime);
    }
    
    public void JumpEvent()
    {
        if (GroundCheeck.isGrounded)
            rig.AddForce(Vector3.up * 100 * JumpStrength);
    }
}
