using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    const string SHIELD_UPGRADE = "Shield Upgrade";
    const string WEAPON_UPGRADE = "Weapon Upgrade";
    const string HEALTH_UPGRADE = "Health Upgrade";
    string upgradeType;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        upgradeType = gameObject.name;
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        // Need to remove the "(Clone)" that gets added to the copy
        // of the prefab name for the upgrade object
        switch (upgradeType.Substring(0, upgradeType.Length - 7))
        {
            case SHIELD_UPGRADE:
                player.upgradeShield();
                break;
            default:
                break;
        }
    }
}
