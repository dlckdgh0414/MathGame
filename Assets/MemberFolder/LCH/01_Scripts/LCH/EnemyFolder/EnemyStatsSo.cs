using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("So/Stats"))]
public class EnemyStatsSo : ScriptableObject
{
	public EnemyStateEnum EnemyName;
	public int Hp;
	public int AttackPower;
	public float AttackDuration;
}
