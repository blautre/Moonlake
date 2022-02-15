using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public CharacterClass characterClass;
    public string displayName;
    public Color characterColor;

    public float health { get; set; }
    public float stamina { get; set; }
    public float mana { get; set; }

    public int vitality { get; set; }
    public int speed { get; set; }
    
    private void Awake()
    {
        speed = 1;
    }

    public enum CharacterClass
    {
        Swordsman,
        Bowman,
        Magician,
        Rogue,
    }
}
