using UnityEngine;
using System.Collections;

public class Dino : MonoBehaviour 
{
    private GameObject dinoToken; 
    
    private Vector3 currentPosition;
    private Vector3 newPosition;
    private float dinoSpeed = 1.0f;
    private float startTime;

	// Use this for initialization
	void Start () 
    {
        dinoToken = GameObject.Find("DinoToken");
        newPosition = dinoToken.transform.position;
        MouseInput.MouseInputEvent += Move;
	}

    void OnDestroy()
    {
        MouseInput.MouseInputEvent -= Move;
    }

    public void Move(Vector3 newPos)
    {
        currentPosition = dinoToken.transform.position;
        startTime = Time.time;
        newPosition = newPos;

        
    }
	
	// Update is called once per frame
	void Update () 
    {
        dinoToken.transform.position = Vector3.Lerp(currentPosition, newPosition, (Time.time - startTime) / dinoSpeed);
	
	}
}
