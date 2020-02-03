using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{

    public PlayerCombat target;
    public bool offencive=true;
    public int dommages;
    public float frequence=1f;
    public List<MonsterController> monstersIn = new List<MonsterController>();
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(ApplyDommagesCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.AuraPoint.position;
        }
    }

    IEnumerator ApplyDommagesCoroutine() {

        void ApplyDommages()
        {
           foreach(MonsterController mc in monstersIn)
            {
                mc.PhotonView.RPC("GetHurt", Photon.Pun.RpcTarget.AllBuffered, dommages);
            }
        }
        while (true)
        {
            yield return new WaitForSeconds(frequence);
            ApplyDommages();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            monstersIn.Add(other.gameObject.GetComponent<MonsterController>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monster")
        {
            monstersIn.Remove(other.gameObject.GetComponent<MonsterController>());
        }
    }
}
