using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectMonsterName : MonoBehaviour
{

    PlayerCombat pc;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerCombat>();
        text=GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        if(pc.Selected != null)
        {
            text.text = pc.Selected.name;
        }
    }
}
