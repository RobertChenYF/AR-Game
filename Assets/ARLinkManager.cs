using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARLinkManager : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHit = new List<ARRaycastHit>();
    public GameObject HitObject;
    [SerializeField]private Camera ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;
            Ray ray = ARCamera.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Target"))

                    HitObject = hit.transform.gameObject;
                    hit.transform.gameObject.GetComponent<BoxController>().Hit();
                }
            }
        else if (HitObject != null)
        {
            HitObject.GetComponent<BoxController>().Normal();
            HitObject = null;
        }
    }
}

