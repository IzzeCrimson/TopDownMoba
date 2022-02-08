using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPSCRIPT : MonoBehaviour
{
    Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {

            rigidbody.AddForce(Vector3.forward);

        }
        if (Input.GetKey(KeyCode.A))
        {

            rigidbody.AddForce(Vector3.left);

        }
        if (Input.GetKey(KeyCode.S))
        {

            rigidbody.AddForce(Vector3.back);

        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right);
        }


    }
}
