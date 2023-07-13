using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Finish : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Collision happened");
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Player entered");
                Gamemanager.Instance.NextLevel();
            }
        }
    }

}