using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    GameObject targetedEnemy;
    CharacterMovement movementScript;

    float autoAttackRange;
    float autoAttackColldown;
    float autoAttackTimer;

    Quaternion facingDirection;
    float rotationY;

    public GameObject projectile;
    GameObject projectileClone;

    // Start is called before the first frame update
    void Start()
    {

        movementScript = GetComponent<CharacterMovement>();

        autoAttackRange = 300;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {

            GetTargetedEnemy();

        }

    }

    void GetTargetedEnemy()
    {

        RaycastHit raycastHit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity))
        {

            if (raycastHit.transform.tag == "Enemy")
            {

                targetedEnemy = raycastHit.transform.gameObject;

                //Get enemystats

            }

        }

    }

    void AttackTargetedEnemy()
    {

        if (targetedEnemy.tag == "Enemy")
        {

            if (Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > autoAttackRange)
            {

                movementScript.navMeshAgent.SetDestination(targetedEnemy.transform.position);
                movementScript.navMeshAgent.stoppingDistance = autoAttackRange;

                //Optimera koden Istället för att Copy/Paste Gör en ny metod som man kallar på

                //Rotate character
                facingDirection = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);

                rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    facingDirection.eulerAngles.y,
                    ref movementScript.rotateVelocity,
                    movementScript.rotateSpeed * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);

            }
            else
            {

                projectileClone = Instantiate(projectile, this.gameObject.transform);

                projectileClone.transform.position = transform.position - targetedEnemy.transform.position;

            }
        }


    }

}

