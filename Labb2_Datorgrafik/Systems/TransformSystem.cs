﻿using Labb2_Datorgrafik.Components;
using Labb2_Datorgrafik.Managers;
using Microsoft.Xna.Framework;

namespace Labb2_Datorgrafik.Systems
{
    class TransformSystem : ISystem
    {
        public void Update(GameTime gametime)
        {
            ComponentManager cm = ComponentManager.GetInstance();
            foreach (var (_, transform) in cm.GetComponentsOfType<TransformComponent>())
            {
                transform.World =
                    Matrix.CreateScale(transform.Scale) *
                    Matrix.CreateFromYawPitchRoll(transform.Rotation.X, transform.Rotation.Y, transform.Rotation.Z) *
                    Matrix.CreateTranslation(transform.Position);
            }
        }
    }
}
