﻿using Labb1_Datorgrafik.Components;
using Labb2_Datorgrafik.Components;
using Labb2_Datorgrafik.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labb2_Datorgrafik.Tools
{
    public static class EntityFactory
    {
        public static int CreateCamera(GraphicsDevice gd, int entityTrackId)
        {
            ComponentManager cm = ComponentManager.GetInstance();

            TransformComponent transform = new TransformComponent()
            {
                Position = new Vector3(-10, 350, -170),
                Rotation = Vector3.Right,
                Up = Vector3.Up
            };

            CameraComponent camera = new CameraComponent()
            {
                FieldOfView = 45,
                NearPlaneDistance = 1,
                FarPlaneDistance = 10000,
                AspectRatio = gd.DisplayMode.AspectRatio,
            };

            TrackingCameraComponent trackComp = new TrackingCameraComponent(entityTrackId, new Vector3(0, 10, 20));

            int cam = cm.AddEntityWithComponents(new IComponent[] { camera, trackComp, transform } );
            return cam;
        }

        public static int CreateHeightMap(GraphicsDevice gd, string heightMapFilePath, string textureFilePath)
        {
            ComponentManager cm = ComponentManager.GetInstance();

            HeightMapComponent hmComp = new HeightMapComponent(gd)
            {
                HeightMapFilePath = heightMapFilePath,
                TextureFilePath = textureFilePath,
            };
            int hm = cm.AddEntityWithComponents(hmComp);

            return hm;
        }

        public static int CreateChopper(GraphicsDevice gd, string modelPath)
        {
            ComponentManager cm = ComponentManager.GetInstance();

            ModelComponent modComp = new ModelComponent(modelPath)
            {
                IsActive = true
            };
            TransformComponent transComp = new TransformComponent()
            {
                Position = new Vector3(20, 350, -170)
            };
            NameComponent nameComp = new NameComponent("Chopper");


            int chop = cm.AddEntityWithComponents(modComp, transComp, nameComp);

            return chop;
        }

        public static int CreateCubeParent(GraphicsDevice gd, string path, float size, Vector3 pos)
        {
            ComponentManager cm = ComponentManager.GetInstance();

            RectangleComponent cubelord = new RectangleComponent(gd, false, size + 1, size, size, path);
            TransformComponent trans = new TransformComponent()
            {
                Position = pos
            };
            int cube = cm.AddEntityWithComponents(cubelord, trans);

            return cube;
        }

        public static int CreateCubeKid(GraphicsDevice gd, string path, float size, int parent, Vector3 pos)
        {
            ComponentManager cm = ComponentManager.GetInstance();

            RectangleComponent cubekid = new RectangleComponent(gd, true, size, size, size, path);
            cubekid.Parent = parent;
            TransformComponent trans = new TransformComponent()
            {
                Position = pos
            };


            int cube = cm.AddEntityWithComponents(cubekid, trans);

            return cube;
        }
    }
}
