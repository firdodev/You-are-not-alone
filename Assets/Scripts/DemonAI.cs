using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAI : MonoBehaviour
{
    public Candle candle;
    [SerializeField] private GameObject player;
    [SerializeField] private float radius = 1f;
    [SerializeField] private float speed = 1.5f;
    public bool chase = false;
    public bool canAttack = false;
    public Transform startingPoint;

    public Animator animator;

    [SerializeField] AnimationClip attackClip;
    [SerializeField] float eventAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        animator = GetComponent<Animator>();
        attackClip.AddAnimationEvent(eventAttackTime, "OnEndAttack");
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
            return;

        // if(candle.CandleOn){
        //     ReturnStartPos();
        //     return;
        // }



        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Player"));
        if(playerCollider)
            chase = true;
        else
            chase = false;
        

        if(chase)
            FollowTarget();
        else
            ReturnStartPos();

        FlipSprite();
    }

    private void FollowTarget(){
        var diff = Vector2.Distance(player.transform.position, transform.position);
        if(diff > 2.5 && canAttack){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }else{
            if(canAttack){
                animator.SetBool("Attack", canAttack);
                player.GetComponent<PlayerMovement>().canPlayerMove = false;
            }else{
                ReturnStartPos();
                if(startingPoint.position == transform.position)
                    canAttack = true;
                player.GetComponent<PlayerMovement>().canPlayerMove = true;
            }
        }
    }

    private void ReturnStartPos(){
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void FlipSprite()
    {
        if(transform.position.x > player.transform.position.x){
            transform.rotation = Quaternion.Euler(0,0,0);
        }else{
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void OnEndAttack(){
        canAttack = false;
        Debug.Log("End of attack animation");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
