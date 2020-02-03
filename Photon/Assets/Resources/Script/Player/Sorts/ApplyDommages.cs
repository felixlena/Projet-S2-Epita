using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ApplyDommages : MonoBehaviour
{

    public int dommages;

    public bool smartCast;
    public MonsterController target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            if (!smartCast)
            {
                if (target == other.GetComponent<MonsterController>())
                {
                    other.gameObject.GetComponent<MonsterController>().PhotonView.RPC("GetHurt", RpcTarget.AllBuffered, dommages);
                    StartCoroutine(TempoDestroy());
                }
            }
            else
            {
                other.gameObject.GetComponent<MonsterController>().PhotonView.RPC("GetHurt", RpcTarget.AllBuffered, dommages);

            }
        }
    }

    IEnumerator TempoDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        PhotonNetwork.Destroy(gameObject);

    }
}
