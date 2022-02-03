using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;

    public float rotateSpeed;
    public float rotateVelocity;
    float rotationY;
    public float maxDistance;

    Quaternion facingDirection;

    // Start is called before the first frame update
    void Start()
    {

        rotateSpeed = 0.075f;
        maxDistance = Mathf.Infinity;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {

            MoveCharacter();

        }


    }

    void MoveCharacter()
    {

        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, maxDistance))
        {
            //Move player to raycast hit location
            navMeshAgent.SetDestination(hitInfo.point);

            //Rotate character
            facingDirection = Quaternion.LookRotation(hitInfo.point - transform.position);

            rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                facingDirection.eulerAngles.y,
                ref rotateVelocity,
                rotateSpeed * (Time.deltaTime * 5));

            transform.eulerAngles = new Vector3(0, rotationY, 0);

        }

    }

    //public void RotateCharacter()
    //{



    //}

}
