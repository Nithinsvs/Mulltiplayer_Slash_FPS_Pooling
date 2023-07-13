using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    [SerializeField] float speed;
    GameObject throwerP;


    public GameObject bulletPrefab;
    [SerializeField] Queue<GameObject> bullets = new Queue<GameObject>();

    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(bulletPrefab, transform);
            temp.SetActive(false);
            bullets.Enqueue(temp);
        }
    }

    void Shoot()
    {
        GameObject go = GetObjectFromPool();
        go.SetActive(true);
        StartCoroutine(Firing(go));
    }

    IEnumerator Firing(GameObject go)
    {
        Vector3 targetPosition = transform.position + Vector3.forward * Time.deltaTime * speed;

        float t = 0f;
        while (t < 10f)
        {
            Debug.Log(go.transform.position);
            t += Time.deltaTime;
            go.transform.position = Vector3.Lerp(transform.position, new Vector3(100, 0, 0), t/10f);
        }
        yield return null;
        SetToPool(go);
    }

    private GameObject GetObjectFromPool()
    {
        if (bullets.Count == 0)
        {
            GameObject obj = Instantiate(bulletPrefab, transform);
            bullets.Enqueue(obj);
        }

        GameObject temp = bullets.Dequeue();
        return temp;
    }

    void SetToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bullets.Enqueue(bullet);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

}
