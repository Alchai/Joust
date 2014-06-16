using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float JumpForceScaler = 3.0f;
    public float MovementSpeed = 2.0f;

    public float MaxVelocity = 1.0f;

    private Vector3 ForceDirctionVector = new Vector3();

    // Use this for initialization
    void Start()
    {
        //InitZ so we do not translate in the Z direction
        ForceDirctionVector.z = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    //Function used to check for all inputs and react accordingly
    void InputCheck()
    {
        //Testing jump, will change based on moblie device
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TODO: Only allow jump certain number of times before colliding with the ground?
            this.rigidbody.AddForce(Vector3.up * JumpForceScaler);
        }

        //Movement
        if (Input.GetKey(KeyCode.D))
        {
            //Moving while capping speed (TODO::Add a check for negative vel if we will be able to move left)
            if (this.rigidbody.velocity.x < MaxVelocity)
                this.rigidbody.AddForce(Vector3.right * MovementSpeed);
        }
    }
}
