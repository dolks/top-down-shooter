using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHPText : MonoBehaviour
{

    TextMeshProUGUI playerHPText;
    Player player;

    void Start()
    {
        playerHPText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "HP: " + player.GetHitPoints().ToString();
    }
}
