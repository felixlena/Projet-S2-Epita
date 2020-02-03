using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetwork : MonoBehaviour, IPunObservable
{

    public Vector3 realPos;
    Quaternion realRot;


    PlayerCombat pc;
    MovePlayer mp;
    PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerCombat>();
        mp = GetComponent<MovePlayer>();
        photonView = GetComponent<PhotonView>();

        GetComponent<PhotonView>().ObservedComponents.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, realPos, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRot, 0.1f);
        }
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            /*bool isAttacking = pc.IsAttacking;
            bool isMoving = mp.IsMoving;
            bool die = pc.IsKo;
            stream.SendNext(isAttacking);
            stream.SendNext(isMoving);
            stream.SendNext(die);*/


            Vector3 pos = transform.position;
            stream.Serialize(ref pos);
            Quaternion rot = transform.rotation;
            stream.Serialize(ref rot);



        }
        else
        {
            /*
            bool isAttacking = (bool)stream.ReceiveNext();
            bool isMoving = (bool)stream.ReceiveNext();
            bool die = (bool)stream.ReceiveNext();
            mp.IsMoving = isMoving;
            pc.IsAttacking = isAttacking;
            pc.IsKo = die;
            */
            realPos=(Vector3)stream.ReceiveNext();
            realRot=(Quaternion)stream.ReceiveNext();

        }
    }
}
