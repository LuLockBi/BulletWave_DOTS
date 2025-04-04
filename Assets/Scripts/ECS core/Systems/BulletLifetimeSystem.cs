
using Unity.Entities;

public partial struct BulletLifetimeSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<BulletTag>();
    }

    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        var ecb = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
            .CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var (bulletStats, entity) in
            SystemAPI.Query<RefRW<BulletStats>>()
                .WithAll<BulletTag>()
                .WithEntityAccess())
        {
            bulletStats.ValueRW.lifeTime -= deltaTime;

            if (bulletStats.ValueRW.lifeTime <= 0)
            {
                ecb.DestroyEntity(entity);
            }
        }
    }
}

