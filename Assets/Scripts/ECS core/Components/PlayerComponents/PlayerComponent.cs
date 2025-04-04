using Unity.Entities;
using UnityEngine;

[InternalBufferCapacity(0)]
public struct PlayerTag : IComponentData
{

}

public struct PlayerMovementInput : IComponentData
{
    public Vector2 move;
}

public struct PlayerStats : IComponentData
{
    public float speed;
    public float health;
}