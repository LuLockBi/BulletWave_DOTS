using UnityEngine;
using Unity.Entities;

public class RotateSpeedAuthoring : MonoBehaviour
{
    public float value;

    private class Baker : Baker<RotateSpeedAuthoring>
    {
        public override void Bake(RotateSpeedAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotateSpeed {
                value = authoring.value });
        }
    }
}

public struct RotateSpeed : IComponentData
{
    public float value;
}