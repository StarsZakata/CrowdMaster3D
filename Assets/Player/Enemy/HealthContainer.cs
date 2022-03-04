using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private int health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Deid;


    public void TakeDamage(int value) {
        health -= value;
        if (health <= 0) {
            health = 0;
            Deid?.Invoke();
        }
        HealthChanged?.Invoke(health);
    }
}
