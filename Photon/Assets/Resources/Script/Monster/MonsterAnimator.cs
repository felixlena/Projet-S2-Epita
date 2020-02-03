using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MonsterAnimator : MonoBehaviour
{
    private PhotonView photonView;
    private Animator animator;
    public Animator Animator => animator;
    private MonsterController mc;

    public Dictionary<string, AnimationClip> animations = new Dictionary<string, AnimationClip>();


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        mc = GetComponent<MonsterController>();
        InitDico();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsMoving", mc.IsMoving);
        animator.SetBool("IsAttacking", mc.IsAttacking);
    }

    public void InitDico()
    {
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;    //Get Animator controller
        for (int i = 0; i < ac.animationClips.Length; i++)                 //For all animations
        {
            Debug.Log(ac.animationClips[i].name);
            animations.Add(ac.animationClips[i].name, ac.animationClips[i]);

        }
    }

    public IEnumerator Die()
    {
        animator.SetBool("Die", true) ;
        yield return new WaitForSeconds(animations["Dead"].length + 1); //le temps de voir le cadavre
    }

   
}
