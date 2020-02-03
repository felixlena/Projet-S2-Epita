using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;

public class MonsterNetwork : MonoBehaviourPunCallbacks, IPunObservable
{

    public int sync_hp;
    MonsterController mc;
    // Start is called before the first frame update
    void Start()
    {
        mc = GetComponent<MonsterController>();
        GetComponent<PhotonView>().ObservedComponents.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(mc.Hp);

        }
        else
        {
            sync_hp = (int)stream.ReceiveNext();
            mc.Hp = sync_hp;
        }
    }
}
