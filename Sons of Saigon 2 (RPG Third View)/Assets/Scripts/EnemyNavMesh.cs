using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavMesh : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public AudioClip SpiderGrowlAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <=0)
        {
            //play death animation
            animator.SetTrigger("Die");
        }
        else
        {
            //play get hit animation
            animator.SetTrigger("Damaged");
        }
    }
}
