using Unity.Collections;
using Unity.Entities;

//public partial struct EnemyHealthSystem : ISystem
//{
//    public void OnUpdate(ref SystemState state)
//    {

//        EntityCommandBuffer ecb = new(Allocator.Temp);

//        foreach (var (health, entity) in SystemAPI
//            .Query<RefRW<EnemyHealth>>()
//            .WithAll<EnemyTag>()
//            .WithEntityAccess())
//        {
//            if (health.ValueRO.currentHealth <= 0)
//            {
//                ecb.DestroyEntity(entity);
//            }
//        }

//        ecb.Playback(state.EntityManager);
//        ecb.Dispose();
//    }
//}
