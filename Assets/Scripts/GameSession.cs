using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    float score = 0;
    [SerializeField] GameObject shieldUpgradePrefab;
    [SerializeField] GameObject weaponUpgradePrefab;
    [SerializeField] GameObject healthUpgradePrefab;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GetScore()
    {
        return score;
    }

    public void ResetGameSession()
    {
        Destroy(gameObject);
    }

    public void UpdateScore(float amount)
    {
        score += amount;
    }

    public GameObject GetShieldUpgradePrefab()
    {
        return shieldUpgradePrefab;
    }
}
