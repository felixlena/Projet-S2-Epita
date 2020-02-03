using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMonsterFond : MonoBehaviour
{

    PlayerCombat pc;
    public UnityEngine.UI.Image fondSelection;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerCombat>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.Selected != null && !pc.Selected.IsDead)
        {
            fondSelection.gameObject.SetActive(true);
        }
        else
        {
            fondSelection.gameObject.SetActive(false);
        }
    }
}
