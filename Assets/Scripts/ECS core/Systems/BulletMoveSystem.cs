using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
public partial struct BulletMoveSystem : ISystem
{
    [BurstCompile]
    public readonly void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (transform, bulletStats, bulletDirection) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<BulletStats>, RefRO<BulletMovement>>().WithAll<BulletTag>())
        {
            transform.ValueRW.Position += bulletStats.ValueRO.bulletSpeed * deltaTime * bulletDirection.ValueRO.bulletDirection;
        }
    }
}
