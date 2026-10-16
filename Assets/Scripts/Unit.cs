using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField] public Health health;
    [SerializeField] public Image healthbar_img;
    public string unitName;
    public int damageAmount;
    public bool isAttacking;
    public Animator unitAnimator;
    public AudioSource attackSource;
    public AudioClip attackClip1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        health = GetComponent<Health>();
        unitAnimator = GetComponent<Animator>();
        if (attackSource == null)
        {
            attackSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            attackSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
