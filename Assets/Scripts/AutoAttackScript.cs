using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackScript : MonoBehaviour
{

    PlayerAttackScript attackScript;
    

    void Start()
    {

        attackScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackScript>();

    }

    
    void Update()
    {

        //this.transform.position = (this.transform.position -
        //   attackScript.targetedObject.transform.position) * (Time.deltaTime * 10);

        transform.position = Vector3.Lerp(transform.position, attackScript.targetedObject.transform.position, Time.deltaTime * 10);


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {

            Destroy(this.gameObject);


        }


    }


}
