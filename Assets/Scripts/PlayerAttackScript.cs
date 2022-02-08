using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    public GameObject targetedObject;
    CharacterMovement movementScript;

    float autoAttackRange;
    float autoAttackColldown;
    float autoAttackTimer;
    bool isAutoAttack;

    Quaternion facingDirection;
    float rotationY;

    public GameObject projectile;
    GameObject projectileClone;

    // Start is called before the first frame update
    void Start()
    {

        movementScript = GetComponent<CharacterMovement>();

        autoAttackRange = 10f;
        isAutoAttack = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {

            GetTargetedObject();

            AttackTargetedEnemy();

        }

    }

    void GetTargetedObject()
    {

        RaycastHit raycastHit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity))
        {


            targetedObject = raycastHit.collider.gameObject;



        }

    }

    void AttackTargetedEnemy()
    {

        if (targetedObject.tag == "Enemy")
        {

            isAutoAttack = true;

            if (Vector3.Distance(targetedObject.transform.position, this.transform.position) 
                > autoAttackRange)
            {

                MoveCharacterToAttackRange();

            }
            else
            {

                projectileClone = Instantiate(projectile, transform.position, Quaternion.identity);


            }

        }
        else
        {
            movementScript.navMeshAgent.stoppingDistance = 0;
        }

    }

    void MoveCharacterToAttackRange()
    {

        movementScript.navMeshAgent.stoppingDistance = autoAttackRange;
        movementScript.navMeshAgent.SetDestination(targetedObject.transform.position);

        //Optimera koden Istället för att Copy/Paste Gör en ny metod som man kallar på

        //Rotate character
        facingDirection = Quaternion.LookRotation(targetedObject.transform.position
            - transform.position);

        rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
            facingDirection.eulerAngles.y,
            ref movementScript.rotateVelocity,
            movementScript.rotateSpeed * (Time.deltaTime * 5));

        transform.eulerAngles = new Vector3(0, rotationY, 0);

    }

}

