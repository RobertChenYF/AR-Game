using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerController : MonoBehaviour
{
    public Slider slider;
    public Transform groundMarker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 currentTransform = new Vector3(groundMarker.transform.position.x, groundMarker.transform.position.y + 
            Mathf.Lerp(0.1f,2.0f,slider.value),groundMarker.transform.position.z);
        transform.position = currentTransform;
    }
}
