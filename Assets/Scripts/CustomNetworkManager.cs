using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    public struct CreateCharacterMessage : NetworkMessage
    {
        public CharacterClass characterClass;
        public string displayName;
        public Color characterColor;
    }

    public enum CharacterClass
    {
        Swordsman,
        Bowman,
        Magician,
        Rogue,
    }

    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        CreateCharacterMessage createCharacterMessage = new CreateCharacterMessage
        {
            characterClass = 0,
            displayName = "Among us",
            characterColor = Color.red
        };

        NetworkClient.Send(createCharacterMessage);

    }

    void OnCreateCharacter(NetworkConnection conn, CreateCharacterMessage message)
    {
        GameObject gameObject = Instantiate(playerPrefab);
        PlayerData playerdata = GetComponent<PlayerData>();
    }
}
