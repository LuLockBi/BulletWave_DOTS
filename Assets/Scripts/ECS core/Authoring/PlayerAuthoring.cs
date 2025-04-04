using Unity.Entities;
using UnityEngine;

public class PlayerAuthoring : MonoBehaviour
{
    public PlayerConfigSO playerConfig;
    public PlayerShootingSO playerShootingSO;

    
public class Baker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<PlayerTag>(entity);

            //movement
            AddComponent(entity, new PlayerMovementInput());
            AddComponent(entity, new PlayerStats {speed = authoring.playerConfig.playerSpeed });

            //shooting
            AddComponent(entity, new PlayerShootingInput());
            AddComponent(entity, new PlayerShooting
            {
                fireRate = authoring.playerShootingSO.fireRate,
                lastFireTime = 0,
                bulletScale = authoring.playerShootingSO.bulletScale
            });
            AddComponent(entity, new BulletPrefab {bulletPrefab = GetEntity(authoring.playerShootingSO.bulletPrefab, TransformUsageFlags.Dynamic) });
            AddComponent(entity, new BulletStats {bulletSpeed =  authoring.playerShootingSO.bulletSpeed});

        }
    }
}






