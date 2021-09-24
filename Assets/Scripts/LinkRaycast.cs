using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkRaycast : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    public List<GameObject> HitObject = new List<GameObject>();

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

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Target"))
                {
                    //Debug.Log("Hit");
                    if (!HitObject.Contains(hit.transform.gameObject))
                    {
                        HitObject.Add(hit.transform.gameObject);
                        hit.transform.gameObject.GetComponent<BoxController>().Hit();
                    }
                    
                }

                // Do something with the object that was hit by the raycast.
            }
            
        }
        else if (Input.GetMouseButtonUp(0))
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

public class Service : MonoBehaviour
{
    public static LinkRaycast linkRaycast;

}
