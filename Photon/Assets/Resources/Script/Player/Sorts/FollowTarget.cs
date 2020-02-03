using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform target;
    public float range = 5;
    public float speed=5;

    Vector3 origine;

    // Start is called before the first frame update
    void Start()
    {
        origine = transform.position;
        StartCoroutine(CheckRangeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.LookAt(target.position + new Vector3(0,1,0));
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    IEnumerator CheckRangeCoroutine()
    {
        void CheckRange()
        {
            if (range != 0)
            {
                if (Vector3.Distance(origine, transform.position) > range)
                {
                    Photon.Pun.PhotonNetwork.Destroy(gameObject);
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
