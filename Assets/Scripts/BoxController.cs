using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Material material;
    public enum Type { White, Blue, Red };
    public Type thisType;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        
        material = GetComponent<MeshRenderer>().material;
        originalColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,20*Time.deltaTime,0),Space.World);
    }

    public void Hit()
    {
        //change color
        material.color = Color.red;
    }

    public void Normal()
    {
        //change back color
        material.color = originalColor;

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
