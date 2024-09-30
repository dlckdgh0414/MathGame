using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float Hp { get; set; }

    public void MinusDamage(float AttackDamage = 0)
    {
        Hp -= AttackDamage;
    }

    public void PlusDamage(float PlusHealth = 0)
    {
        Hp += PlusHealth;
    }

    private void Die(float zeroHp)
    {
        if(Hp == zeroHp)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Die(0);
    }

}
