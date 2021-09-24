using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkRaycast : MonoBehaviour
{
    [SerializeField]private Camera gameCamera;
    public GameObject HitObject;
    
    // Start is called before the first frame update
    void Awake()
    {
        Service.linkRaycast = this;
    }
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
            if (hit.transform.gameObject.CompareTag("Target"))
            {
                //Debug.Log("Hit");
                HitObject = hit.transform.gameObject;
                HitObject.GetComponent<BoxController>().Hit();
            }
            

            // Do something with the object that was hit by the raycast.
        }
        else if(HitObject != null)
        {
            HitObject.GetComponent<BoxController>().Normal();
            HitObject = null;
        }
    }
}

public class Service : MonoBehaviour
{
    public static LinkRaycast linkRaycast;
    
}
