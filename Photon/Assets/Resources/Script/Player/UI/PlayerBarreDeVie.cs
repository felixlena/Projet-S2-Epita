using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarreDeVie : MonoBehaviour
{

    PlayerCombat pc;
    public Image barre;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponentInParent<PlayerCombat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        barre.fillAmount = Mathf.Lerp(barre.fillAmount, (float)pc.Hp / pc.HpMax, 0.1f);
    }
}
