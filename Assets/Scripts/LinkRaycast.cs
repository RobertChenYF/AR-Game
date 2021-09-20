using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkRaycast : MonoBehaviour
{
    private Camera gameCamera;
    public GameObject HitObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {

            Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.
        }
        else
        {
            HitObject = null;
        }
    }
}
