using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyController : HVRDamageHandlerBase
{
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] private float TimeBetweenAttacks = 1f ;
    [SerializeField] private float damage = 10f;
    [SerializeField] private int deadDistance = 2;
    [SerializeField] private float maxHealth = 50f;
    [SerializeField] private Image healthImage;
    [SerializeField] private Image healthBackground;
    
    private float _currentHealth;
    
    private PlayerData _player;

    private Transform _cameraTransform;
    
    private float _timerAttack = 0;

    private Animator anim;

    public AudioSource audio;
    
    
    [Inject]
    public void Construct(PlayerData player)
    {
        _player = player;
    }

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("Go_Battle", true);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _cameraTransform = _player.GetComponent<HVRPlayerController>().Camera;
        _currentHealth = maxHealth;
        

    }
    
    void Update()
    {
        audio.Play();
        agent.destination = _player.gameObject.transform.position;
        healthImage.transform.LookAt(_cameraTransform);
        healthBackground.transform.LookAt(_cameraTransform);
        if (Vector3.Distance(_player.gameObject.transform.position, gameObject.transform.position) < deadDistance)
        {
            
            _timerAttack -= Time.deltaTime;
            if (_timerAttack <= 0)
            {
                //anim = GetComponent<Animator>();
                anim.SetTrigger("Attack");
                _player.TakeDamage(damage);
                _timerAttack = TimeBetweenAttacks;
                
                
                
            }
            
        }
    }

    public override void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        healthImage.fillAmount = _currentHealth / maxHealth ;
        if (_currentHealth <= 0)
        {
            
            Destroy(gameObject);
        }
    }
    
}
