using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    //Scaler amount to how fast to scroll texture
    public float TextureScrollScale = 1.0f;

    //Game Object to get the cameras positon
    public GameObject Player;

    //A vector to contantly scroll the background with the camera;
    private Vector3 UpdatedPositionVector = new Vector3();

    Vector2 TextureOffset = new Vector2();

	// Use this for initialization
	void Start () 
    {
        UpdatedPositionVector.y = this.transform.position.y;
        UpdatedPositionVector.z = this.transform.position.z;

        TextureOffset.y = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdatedPositionVector.x = Player.transform.position.x;
        this.transform.position = UpdatedPositionVector;

        //_MainTex
        //print(Player.rigidbody.velocity.x);
        TextureOffset.x = TextureOffset.x + (Player.rigidbody.velocity.x * TextureScrollScale);
        if (TextureOffset.x > 1.0f)
            TextureOffset.x = 0.0f;
        //print(TextureOffset.x);
        this.transform.renderer.material.SetTextureOffset("_MainTex", TextureOffset);
	}
}
