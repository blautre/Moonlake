using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    public struct CreateCharacterMessage : NetworkMessage
    {
        public PlayerData.CharacterClass characterClass;
        public string displayName;
        public Color characterColor;
        
    }

    public List<Color> colors = new List<Color>
    {
        Color.yellow,
        Color.black,
        Color.blue,
        Color.red,
        Color.magenta,
        Color.gray,
        Color.green,
        Color.cyan,
        new Color(255, 192, 203),
        new Color(210, 105, 30)
    };

    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        int randomColor = Random.Range(1, colors.Count) -1;

        CreateCharacterMessage createCharacterMessage = new CreateCharacterMessage
        {
            characterClass = (PlayerData.CharacterClass)Random.Range(0, 3),
            displayName = "Amongus",
            characterColor = colors[randomColor]
        };

        NetworkClient.Send(createCharacterMessage);
        colors.RemoveAt(randomColor);
    }

    void OnCreateCharacter(NetworkConnection conn, CreateCharacterMessage message)
    {
        GameObject playerObject = Instantiate(playerPrefab);
        PlayerData playerdata = playerObject.GetComponent<PlayerData>();

        
        playerdata.characterClass = message.characterClass;
        playerdata.displayName = message.displayName;
        playerdata.characterColor = message.characterColor;

        NetworkServer.AddPlayerForConnection(conn, playerObject);
    }
}
