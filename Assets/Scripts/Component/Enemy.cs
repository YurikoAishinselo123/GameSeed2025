using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10; // Nilai damage spesifik untuk musuh ini

    public int GetDamage()
    {
        return damage;
    }
}
