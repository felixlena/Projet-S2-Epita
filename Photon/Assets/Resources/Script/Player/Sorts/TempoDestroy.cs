using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TempoDestroy : MonoBehaviour
{

    public float duree= 0;

    // Start is called before the first frame update
    void Start()
    {
        if (duree > 0)
        {
            StartCoroutine(TempoBeforeDestroy());
        }

    }


    IEnumerator TempoBeforeDestroy()
    {
        yield return new WaitForSeconds(duree);
        PhotonNetwork.Destroy(gameObject);
    }



}
