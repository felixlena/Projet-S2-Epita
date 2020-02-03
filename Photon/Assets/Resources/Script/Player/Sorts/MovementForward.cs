using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovementForward : MonoBehaviour
{

    public float speed;
    public float range = 0;
    
    Vector3 origine;
    // Start is called before the first frame update
    void Start()
    {
        if (range > 0)
        {
            origine = transform.position;
            StartCoroutine(CheckRangeCoroutine());
        }
        RaycastHit hit;
        Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator CheckRangeCoroutine()
    {
        void CheckRange()
        {
            if (range != 0)
            {
                if (Vector3.Distance(origine, transform.position) > range)
                {
                    PhotonNetwork.Destroy(gameObject);
                }
            }
        }

        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            CheckRange();
        }
    }

}
