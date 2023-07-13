using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class Enemy : MonoBehaviour
    {
        float enemyAttackSpeed = 0.8f;
        GameObject playerCharacter;

        private void Awake()
        {
            playerCharacter = GameObject.FindGameObjectWithTag("Player");
            if (playerCharacter != null)
                PlayerManager.playerInRange += PlayerInRange;
        }

        private void PlayerInRange()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 20f);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.CompareTag("Player") && gameObject.activeSelf)
                {
                    StartCoroutine(Move());
                    break;
                }
            }
        }
        IEnumerator Move()
        {
            Vector3 pos = playerCharacter.transform.position;
            Debug.Log("player position = " + pos);
            while (playerCharacter)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, transform.position.y, pos.z),
                                                        enemyAttackSpeed * Time.deltaTime);
                yield return null;
            }
        }

    }

}