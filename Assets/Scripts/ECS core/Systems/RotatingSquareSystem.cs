using Unity.Entities;
using Unity.Transforms;


public partial struct RotatingSquareSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> localTransform, RefRO<RotateSpeed> rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>().WithAll<PlayerTag>())
        {
            localTransform.ValueRW = localTransform.ValueRO.RotateZ(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
        }
    }
}
