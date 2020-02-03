using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DisableUI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponentInParent<PhotonView>().IsMine)
        {
            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
