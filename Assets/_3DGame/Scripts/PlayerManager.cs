using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PlayerManager : MonoBehaviour
{
    public static GameObject localPlayerInstance;
    public static UnityAction playerInRange;

    [SerializeField] float knifeSpeed = 0f;
    [SerializeField] float rotateSpeed = 0f;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float gravity = 8f;
    [SerializeField] GameObject knife;

    Vector3 direction;
    Vector3 jumpUp = Vector3.up;
    CharacterController player;


    bool foundEnemy = false;
    bool jump;
    bool nextFloor;



    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (player.isGrounded)
        {
            //CheckEnemies();

            direction = Vector3.zero;
            direction.z = 1;
            jump = true;
        }
        else
        {
            direction.y -= gravity * Time.deltaTime;
            player.Move(direction * speed * Time.deltaTime);
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("---Pointer is on screen---");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    StartCoroutine(MoveKnife(hit.point));
                }
            }
        }

        if (Movement.pressed)
        {
            Debug.Log("---Pointer is on ui---");

            direction = Vector3.zero;
            direction.z = 1;
            direction.y -= gravity * Time.deltaTime;
            player.Move(direction * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            player.Move(jumpUp * speed * Time.deltaTime);
        }

    }
    IEnumerator MoveKnife(Vector3 pos)
    {
        GameObject clone = Instantiate(knife, transform.position + new Vector3(0, 0, 1), Quaternion.identity);
        while (clone.activeSelf)
        {
            clone.transform.position = Vector3.MoveTowards(clone.transform.position, pos, knifeSpeed * Time.deltaTime);
            clone.transform.Rotate(new Vector3(50, 0, 0));
            yield return null;
        }
        //CheckEnemies();
    }

    void CheckEnemies()
    {
        Debug.Log("Checking enemies");
        int i = 0;
        foundEnemy = false;
        nextFloor = true;

        Collider[] colls = Physics.OverlapSphere(transform.position, 20f);
        while (i < colls.Length)
        {
            if (colls[i].gameObject.tag == "Enemy" && player.isGrounded)
            {
                foundEnemy = true;
                nextFloor = false;
            }
            i++;
        }
    }

}