using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class SelectionSort : MonoBehaviour
{

    public GameObject[] prefabsSorts;
    public Dictionary<string, GameObject> sorts = new Dictionary<string, GameObject>();
    public List<string> choisis = new List<string>();
    public List<float> choisisCDR = new List<float>();

    PlayerCombat pc;

    // Start is called before the first frame update
    void Start()
    {
        InitDicoSort();
        pc =GetComponent<PlayerCombat>();


        StartCoroutine(ReduceCDRCoroutine());
        choisis.Add(prefabsSorts[0].name);
        choisisCDR.Add(0);
        choisis.Add(prefabsSorts[1].name);
        choisisCDR.Add(0);
        choisis.Add(prefabsSorts[2].name);
        choisisCDR.Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool Cast(int sortChoisi)
    {
        if (sortChoisi > choisis.Count)
        {
            return false;
        }
        if (choisis[sortChoisi] == "BouleRose" && choisisCDR[sortChoisi]==0)
        {
            if (CheckCondition(sortChoisi) && BouleRose(pc.CastPoint))
            {
                ApplyReaction( sortChoisi);
                return true;
            }
        }
        else if(choisis[sortChoisi] == "AuraDeLove" && choisisCDR[sortChoisi]==0)
        {
            if (CheckCondition(sortChoisi) && AuraDeLove(pc.AuraPoint))
            {
                ApplyReaction( sortChoisi);
                return true;
            }
        }
        else if (choisis[sortChoisi] == "BouleBleue" && choisisCDR[sortChoisi]==0)
        {
            if (CheckCondition(sortChoisi) && BouleBleue(pc.AuraPoint, pc.Selected))
            {
                ApplyReaction( sortChoisi);
                return true;
            }
        }
        return false;
    }


    bool CheckCondition(int sortChoisi)
    {
        if (GetManaCost(sortChoisi) < pc.Mana && choisisCDR[sortChoisi]==0)
        {
            return true;
        }
        return false;

    }
    void ApplyReaction(int sortChoisi)
    {
        pc.PhotonView.RPC("UseMana", RpcTarget.All, GetManaCost(sortChoisi));
        choisisCDR[sortChoisi] = GetCDR(sortChoisi);

    }

    public bool BouleRose(Transform castPoint)
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Sorts", "BouleRose"), castPoint.position, castPoint.rotation);
        return true;
    }

    public bool AuraDeLove(Transform auraPoint)
    {
        GameObject a = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Sorts", "AuraDeLove"), auraPoint.position, auraPoint.rotation);
        a.GetComponent<Aura>().target = pc;
        return true;
    }

    public bool BouleBleue(Transform auraPoint, MonsterController selected)
    {
        if (selected != null && !selected.IsDead)
        {
            GameObject a = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Sorts", "BouleBleue"), auraPoint.position, auraPoint.rotation);
            a.GetComponent<FollowTarget>().target = selected.transform;
            a.GetComponent<ApplyDommages>().target = selected;
            return true;
        }
        return false;
    }



    float GetCDR(int sortChoisi)
    {
        if (sortChoisi > choisis.Count)
        {
            return 0;
        }
        return sorts[choisis[sortChoisi]].GetComponent<Spell>().CDR;

    }


    int GetManaCost(int sortChoisi)
    {
        if (sortChoisi > choisis.Count)
        {
            return 0;
        }
        return sorts[choisis[sortChoisi]].GetComponent<Spell>().manaCost;

    }


    void InitDicoSort()
    {
        for (int i = 0; i < prefabsSorts.Length; i++)                 //For all animations
        {
            sorts.Add(prefabsSorts[i].name, prefabsSorts[i]);

        }
    }


    IEnumerator ReduceCDRCoroutine()
    {
        void ReduceCDR()
        {
            for (int i = 0; i < choisis.Count; i++)
            {
                choisisCDR[i] -= 0.1f;
                if (choisisCDR[i] < 0)
                {
                    choisisCDR[i] = 0;
                }
            }
        }
        
       while (true)
        {
            ReduceCDR();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
