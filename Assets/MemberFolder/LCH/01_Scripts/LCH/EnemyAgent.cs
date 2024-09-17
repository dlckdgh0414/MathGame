using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : MonoBehaviour
{
    public Rigidbody2D RbCompo { get; protected set; }
    public Health HelathCompo { get; protected set;  }
    public bool IsDie { get; protected set; } = false;

    public bool CanStateChangeble { get; protected set; }

    private void Awake()
    {
        RbCompo = GetComponent<Rigidbody2D>();
        HelathCompo = GetComponent<Health>();
    }
}
