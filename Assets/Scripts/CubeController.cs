using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    public float rotationSpeed = 10.0f;
    public float scaleSpeed = 10.0f;

    private float horizontalInput;
    private float forwardInput;
    private float DiagonalInput;

    private Vector3 startScale; 
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        Debug.Log(Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        DiagonalInput = Input.GetAxis("Diagonal");

        transform.Rotate(Vector3.forward, rotationSpeed * forwardInput * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
        transform.Rotate(Vector3.right, rotationSpeed * DiagonalInput * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += transform.localScale * scaleSpeed * Time.deltaTime;
        }
        else if(transform.localScale.magnitude > startScale.magnitude)
        {
            transform.localScale -= transform.localScale * scaleSpeed * Time.deltaTime;
        }
        
        if(transform.localScale.x < startScale.x)
        {
            transform.localScale = new Vector3(startScale.x, transform.localScale.y, transform.localScale.z);
        }
        if (transform.localScale.y < startScale.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, startScale.y, transform.localScale.z);
        }
        if (transform.localScale.z < startScale.z)
        {
            transform.localScale = new Vector3(transform.localScale.z, transform.localScale.y, startScale.z);
        }
        

    }
}
