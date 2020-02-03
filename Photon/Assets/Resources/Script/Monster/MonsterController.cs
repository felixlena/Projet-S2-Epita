using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MonsterController : MonoBehaviour
{

    private PhotonView photonView;
    public PhotonView PhotonView => photonView;
    MonsterAnimator animator;
    public PlayerCombat[] players;
    public PlayerCombat target = null;

    public bool InRange
    {
        get
        {
            if (target != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool IsMoving = false;
    public bool InRangeAttack
    {
        get
        {
            if (target != null && Vector3.Distance(transform.position, target.transform.position) <= rangeAttack)
            {
                return true;
            }
            return false;
        }
    }
    public bool IsAttacking;



    private bool isDead = false;
    [SerializeField]
    private bool ko = false;
    public bool IsDead => isDead;
    public bool IsKo
    {
        get
        {
            return ko;
        }
        set
        {
            if (!value)
            {
                IsMoving = false;
                IsAttacking = false;
            }
            ko = value;
        }
    }

    [SerializeField]
    private int hpMax = 100;
    public int HpMax => hpMax;
    [SerializeField]
    private int hp;
    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            if (value <= 0)
            {
                hp = 0;
                IsKo = true;
            }
            else if (value > hpMax)
            {
                hp = hpMax;
            }
            else
            {
                hp = value;
            }
        }
    }



    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float range = 5f;
    [SerializeField]
    private float rangeAttack = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindObjectsOfType<PlayerCombat>();
        photonView = GetComponent<PhotonView>();
        animator = GetComponent<MonsterAnimator>();
        Hp = hpMax;
        IsAttacking = false;
        StartCoroutine(GetCloserPlayerCoroutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsKo)
        {
            Traque();
        }
        else if(!isDead)
        {
            StartCoroutine(Die());
        }

    }

    void Traque()
    {
        if (target == null )
        { 
            IsMoving = false;
            IsAttacking = false;
        }
        else if (Vector3.Distance(transform.position, target.transform.position) > range)
        {
            target = null;
            IsAttacking = false;
            IsMoving = false;

        }
        else if (InRangeAttack && !IsAttacking)
        { 
            transform.LookAt(target.transform);
            IsAttacking = true;
            IsMoving = false;
            StartCoroutine(BasicAttack());
        }
        else if (!IsAttacking)
        {
            IsMoving = true;
            IsAttacking = false;
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime); // fonction move pour path finding a venir
        }

    }


    IEnumerator Die()
    {
        StartCoroutine(animator.Die());
        yield return new WaitForSeconds(animator.animations["Dead"].length);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        isDead = true;
    }
    IEnumerator BasicAttack()
    {
        yield return new WaitForSeconds(animator.animations["BasicAttack"].length);
        if (target != null && InRangeAttack)
        {
            target.PhotonView.RPC("GetHurt", RpcTarget.All, 10);
        }
        IsAttacking = false;
    }


    public void Hurt(int dommages)
    {
        target.GetHurt(dommages);
    }

    [PunRPC]
    public void GetHurt(int dommages)
    {
        Hp -= dommages;
    }


    IEnumerator GetCloserPlayerCoroutine()
    {
        void GetCloserPlayer() //peu opti
        {
            Transform t = null;
            foreach (PlayerCombat p in players)
            {
                if (Vector3.Distance(transform.position, p.transform.position) <= range)
                {
                    if (t == null)
                    {
                        t = p.transform;
                    }
                    else if (t != null && Vector3.Distance(transform.position, t.position) >= Vector3.Distance(transform.position, p.transform.position)) //dist precedent > dist actuel ?
                    {
                        t = p.transform;
                    }
                }
            }
            if (t != null)
            {
                target = t.GetComponent<PlayerCombat>();
            }
            else
            {
                target = null;
            }
        }
        while (true)
        {
            players = GameObject.FindObjectsOfType<PlayerCombat>();
            GetCloserPlayer();
            yield return new WaitForSeconds(1f);
        }
    }
    

   
}
