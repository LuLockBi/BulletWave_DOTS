using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct PlayerShootingSystem : ISystem
{
    public readonly void OnUpdate(ref SystemState state)
    {
        float time = (float)SystemAPI.Time.ElapsedTime;

        if (!Input.GetMouseButton(0))
            return;

        EntityCommandBuffer ecb = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);

        foreach (var (transform, bulletPrefab,playerShooting, shootingInput) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<BulletPrefab>, RefRW<PlayerShooting>, RefRO<PlayerShootingInput>>())
        {
            if (time < playerShooting.ValueRO.lastFireTime + playerShooting.ValueRO.fireRate)
                continue;

            playerShooting.ValueRW.lastFireTime = time;

            Entity bullet = ecb.Instantiate(bulletPrefab.ValueRO.bulletPrefab);


            ecb.SetComponent(bullet, LocalTransform.FromPositionRotationScale(
                transform.ValueRO.Position,
                transform.ValueRO.Rotation,
                playerShooting.ValueRO.bulletScale
            ));

            ecb.SetComponent(bullet, new BulletMovement
            {
                bulletDirection = shootingInput.ValueRO.shootDirection
            });
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
    
}
