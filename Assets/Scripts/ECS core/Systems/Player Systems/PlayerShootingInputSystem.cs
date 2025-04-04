using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct PlayerShootingInputSystem : ISystem
{
    Vector2 mousePosition;
    public void OnUpdate(ref SystemState state)
    {
        bool isShooting = Input.GetButton("Fire1");
        if (isShooting)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        foreach (var (shootingInput, playerTransform) in SystemAPI.Query<RefRW<PlayerShootingInput>, RefRO<LocalTransform>>())
        {
            shootingInput.ValueRW.isShooting = isShooting;

            if (isShooting)
            {
                Vector2 playerPosition = playerTransform.ValueRO.Position.xy;
                Vector2 direction = (mousePosition - playerPosition).normalized;
                shootingInput.ValueRW.shootDirection = new Unity.Mathematics.float3(direction.x, direction.y, 0f);
            }

        }


    }
}
