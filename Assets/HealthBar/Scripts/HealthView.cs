using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class HealthView : MonoBehaviour
{
    public abstract void DrawHealth(float currentHealth, float maxHealth);
}