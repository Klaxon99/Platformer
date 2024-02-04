using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private float _healthRecoveryCount;

    public float HealthRecoveryCount => _healthRecoveryCount;
}