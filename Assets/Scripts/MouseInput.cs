using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseInput : MonoBehaviour
{
    public delegate void NotifyOnMouseInput(Vector3 newPosition);
    public static event NotifyOnMouseInput MouseInputEvent = delegate { };

    private GameObject dino;
    private Vector3 mousePos;
    private Vector3 worldPos; 

    // Use this for initialization
    void Start()
    {
        dino = GameObject.Find("DinoToken");
    }

    // Update is called once per frame
    void Update()
    {
        const int orthographicSizeMin = 5;
        const int orthographicSizeMax = 100;

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Dino Moved to " + worldPos);


           // dino.transform.position = new Vector3(worldPos.x, 1, worldPos.z);
           MouseInputEvent(new Vector3(worldPos.x, 1, worldPos.z));

        }
 

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // back
        {
            Camera.main.orthographicSize--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
        {
            Camera.main.orthographicSize++;
        }

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);
    }
}