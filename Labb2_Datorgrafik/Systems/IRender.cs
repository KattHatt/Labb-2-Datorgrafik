﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Labb2_Datorgrafik.Systems
{
    public interface IRender
    {
        void Render(GraphicsDevice gd, BasicEffect be);
        void Load(ContentManager content);
    }
}
