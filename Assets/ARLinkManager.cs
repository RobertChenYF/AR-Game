using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARLinkManager : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    private List<ARRaycastHit> raycastHit = new List<ARRaycastHit>();
    public List<GameObject> HitObject = new List<GameObject>();
    [SerializeField] private Camera ARCamera;
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

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.CompareTag("Target"))

                        if (!HitObject.Contains(hit.transform.gameObject))
                        {
                            HitObject.Add(hit.transform.gameObject);
                            hit.transform.gameObject.GetComponent<BoxController>().Hit();
                        }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (HitObject.Count >= 3)
                {
                    Debug.Log("eliminate");
                    while (HitObject.Count > 0)
                    {
                        GameObject a = HitObject[0];

                        HitObject.RemoveAt(0);
                        a.GetComponent<BoxController>().Eliminate();
                    }

                }
            }

        }
        else if (HitObject.Count > 0)
        {
            foreach (GameObject cube in HitObject)
            {
                cube.GetComponent<BoxController>().Normal();
            }
            HitObject.Clear();
        }
    }
}

