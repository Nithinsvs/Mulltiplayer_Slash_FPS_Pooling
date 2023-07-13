using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    [SerializeField] float camSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
            if (Movement.pressed)
            {
                if (camTransform == null)
                    OnStartFollowing();
            }
    }
    void OnStartFollowing()
    {
        //camTransform = Camera.main.transform;
        //camTransform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        //camTransform.position = Vector3.Lerp(camTransform.position, this.transform.position, camSpeed * Time.deltaTime);
        //camTransform.LookAt(this.transform.position);
    }

}
