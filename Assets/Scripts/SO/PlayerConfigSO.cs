using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsConfig", menuName = "Game/PlayerConfig/PlayerStatsConfig")]
public class PlayerConfigSO : ScriptableObject
{
    public GameObject playerPrefab;
    public float playerSpeed;
    public int playerHealth;
}
