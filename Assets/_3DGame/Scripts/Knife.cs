using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided enemy");

            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }

}
