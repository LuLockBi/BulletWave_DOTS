using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShootingConfig", menuName = "Game/PlayerConfig/PlayerShootingConfig")]
public class PlayerShootingSO : ScriptableObject
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletScale;
    public float fireRate;
}
