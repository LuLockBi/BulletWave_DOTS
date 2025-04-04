using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public partial struct PlayerInputSystem : ISystem
{
    public readonly void OnUpdate(ref SystemState state)
    {
        float2 moveInput = float2.zero;

        if (Input.GetKey(KeyCode.W)) moveInput.y += 1;
        if (Input.GetKey(KeyCode.S)) moveInput.y -= 1;
        if (Input.GetKey(KeyCode.A)) moveInput.x -= 1;
        if (Input.GetKey(KeyCode.D)) moveInput.x += 1;

        foreach (RefRW<PlayerMovementInput> input in SystemAPI.Query<RefRW<PlayerMovementInput>>())
        {
            if (!math.all(moveInput == float2.zero))
            {
                moveInput = math.normalize(moveInput);
            }

            input.ValueRW.move = moveInput;
        }
    }
}
