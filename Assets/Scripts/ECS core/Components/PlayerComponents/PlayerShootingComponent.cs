using Unity.Entities;

public struct PlayerShootingInput : IComponentData
{
    public bool isShooting;
    public Unity.Mathematics.float3 shootDirection;
}

public struct PlayerShooting : IComponentData
{
    public float fireRate;
    public float lastFireTime;
    public float bulletScale;
}