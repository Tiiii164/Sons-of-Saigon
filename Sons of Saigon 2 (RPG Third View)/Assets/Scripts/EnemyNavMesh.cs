using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;
public class EnemyNavMesh : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;

    //private AudioSource enemyAudio;

    private HealthSystem healthSystem;

    //public AudioClip SpiderChaseAudioClip;
    //public AudioClip SpiderChaseAudioClip2;
    //public AudioClip ChaseThemeAudioClip;
    //public AudioClip SpiderPatrolAudioClip;
    //private bool hasPlayedTheme = false;


    public void Awake()
    {
        healthSystem = new HealthSystem(HP);
        healthSystem.OnDead += HealthSystem_OnDead;
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
    }

   



    // Start is called before the first frame update
    public void Start()
    {
        //enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {
        // Check if the animator is in the "Chase" state
       /* if (animator.GetCurrentAnimatorStateInfo(0).IsName("ChaseState") && !hasPlayedTheme)
        {
            // Play the ChaseThemeAudioClip
            //enemyAudio.PlayOneShot(SpiderChaseAudioClip);
            //enemyAudio.PlayOneShot(SpiderChaseAudioClip2);
            hasPlayedTheme = true;
        }else
        {
            hasPlayedTheme = false;
        }*/
    }
   
    public void Damage(int damageAmount)
    {
        /*if (HP <= 0)
       {
           //play death animation
           animator.SetTrigger("Die");
       }
       else
       {
           //play get hit animation
           animator.SetTrigger("Damaged");
       }*/
        healthSystem.Damage(damageAmount);
       
    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Damaged");
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Die");
        Destroy(gameObject,5);
    }
}

    
 
