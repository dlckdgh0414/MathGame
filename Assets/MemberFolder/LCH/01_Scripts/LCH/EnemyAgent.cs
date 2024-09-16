using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : MonoBehaviour
{
    public Animator AnimatorComponent { get; protected set; }
    public Rigidbody2D RbCompo { get; protected set; }
    public Health HelathCompo { get; protected set;  }
    public bool IsDie { get; protected set; } = false;

    public bool CanStateChangeble { get; protected set; }

    private void Awake()
    {
        AnimatorComponent = GameObject.Find("Visual").GetComponent<Animator>();
        RbCompo = GetComponent<Rigidbody2D>();
        HelathCompo = GetComponent<Health>();
    }
}
