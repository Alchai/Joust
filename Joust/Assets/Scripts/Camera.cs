using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    //Object to follow
    public GameObject MainCharacterController;

    private float MinYValue = 0.0f;
    private float MinXValue = 0.0f;

    private float MaxYValue = 0.0f;
    private float MaxXvalue = 0.0f;

    //A vector used to update the cameras position (Only update X and Y)
    private Vector3 PositionUpdateVector = new Vector3();

    //Intialization
	void Start () 
    {
        MinYValue = this.transform.position.y;
        MinXValue = this.transform.position.x;
        MaxYValue = GameObject.Find("CeilingTiles").transform.GetChild(0).transform.position.y - (this.camera.orthographicSize);
        print(GameObject.Find("CeilingTiles").transform.GetChild(0).transform.position.x);
        print(this.camera.orthographicSize);
        print(MaxYValue);
        this.PositionUpdateVector.z = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Update the cameras Y
        if (MainCharacterController.transform.position.y < MinYValue)
        {
            PositionUpdateVector.y = MinYValue;
        }
        else if (MainCharacterController.transform.position.y > MaxYValue)
        {
            PositionUpdateVector.y = MaxYValue;
        }
        else
        {
            PositionUpdateVector.y = MainCharacterController.transform.position.y;
        }

        //Update the camers X
        if(MainCharacterController.transform.position.x < MinXValue )
        {
            PositionUpdateVector.x = MinXValue;
        }
        else
        {
            PositionUpdateVector.x = MainCharacterController.transform.position.x;
        }

        //Update the camera with the new postion
        this.transform.position = PositionUpdateVector;
	}
}
