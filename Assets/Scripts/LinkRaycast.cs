using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkRaycast : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    public List<GameObject> HitObject = new List<GameObject>();

    public float movementSum;
    public float rotationSum;
    public Vector3 PositionLastFrame;
    public Vector3 RotationLastFrame;

    // Start is called before the first frame update
    void Awake()
    {
        Service.linkRaycast = this;
        
    }
    void Start()
    {
        Service.indicatorController.PositionLastFrame = gameCamera.transform.position;
        Service.indicatorController.RotationLastFrame = gameCamera.transform.rotation.eulerAngles;
        Service.indicatorController.PositionCurrentFrame = gameCamera.transform.position;
        Service.indicatorController.RotationCurrentFrame = gameCamera.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Service.indicatorController.PositionCurrentFrame = gameCamera.transform.position;
        Service.indicatorController.RotationCurrentFrame = gameCamera.transform.rotation.eulerAngles;
        RaycastHit hit;
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Service.indicatorController.ShowIndicator();
            Service.indicatorController.SetPos(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Target"))
                {
                    //Debug.Log("Hit");
                    if (!HitObject.Contains(hit.transform.gameObject))
                    {
                        if (HitObject.Count == 0)
                        {
                            HitObject.Add(hit.transform.gameObject);
                            hit.transform.gameObject.GetComponent<BoxController>().Hit();
                        }
                        else
                        {
                            if (HitObject[0].GetComponent<BoxController>().thisType == hit.transform.gameObject.GetComponent<BoxController>().thisType)
                            {
                                HitObject.Add(hit.transform.gameObject);
                                hit.transform.gameObject.GetComponent<BoxController>().Hit();
                            }
                        }

                    }

                }

                // Do something with the object that was hit by the raycast.
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Service.indicatorController.CloseIndicator();
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


