using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARGameManager : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHit = new List<ARRaycastHit>();
    [SerializeField] private GameObject cube;
    private GameObject spawnedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //send a raycast with a touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (raycastManager.Raycast(touch.position,raycastHit))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    
                    spawnedObject = Instantiate(cube,raycastHit[0].pose.position,Quaternion.identity);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    if (spawnedObject != null)
                    {
                        spawnedObject.transform.position = raycastHit[0].pose.position;
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {

                }
            }
        }

    }
}
