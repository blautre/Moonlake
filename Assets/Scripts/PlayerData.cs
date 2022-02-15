using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : NetworkBehaviour
{
    public float health { get; set; }
    public float stamina { get; set; }
    public float mana { get; set; }

    public int vitality { get; set; }
    public int speed { get; set; }

    public enum CharacterClass
    {
        Swordsman,
        Bowman,
        Magician,
        Rogue,
    }
}
