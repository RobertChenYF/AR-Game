using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Material material;
    public 

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit()
    {
        //change color
        material.color = Color.blue;
    }

    public void Normal()
    {
        //change back color
        material.color = Color.white;

    }

    public void Highlight()
    {
        material.color = Color.red;
    }

    public void Eliminate()
    {
        Destroy(gameObject);
    }
}
