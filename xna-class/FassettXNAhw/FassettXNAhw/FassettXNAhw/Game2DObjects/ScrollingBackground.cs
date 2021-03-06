﻿#region File Description
//-----------------------------------------------------------------------------
// ScrollingBackground.cs
//
//-----------------------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FassettXNAhw.Game2DObjects
{
    /// <summary>class for scrolling background</summary>
    public class ScrollingBackground
    {
        
        private Vector2 screenpos, origin, texturesize;
        private Texture2D mytexture;
        private int screenheight;



        /// <summary>called as part of LoadContent() in game</summary>
        public void Load( GraphicsDevice device, Texture2D backgroundTexture )
        {
            mytexture = backgroundTexture;
            screenheight = device.Viewport.Height;
            int screenwidth = device.Viewport.Width;

            // Set the origin so that we're drawing from the 
            // center of the top edge.
            origin = new Vector2( mytexture.Width / 2, 0 );

            // Set the screen position to the center of the screen.
            screenpos = new Vector2( screenwidth / 2, screenheight / 2 );

            // Offset to draw the second texture, when necessary.
            texturesize = new Vector2( 0, mytexture.Height );
        }



        /// <summary>
        /// called as part of Update() in game
        /// </summary>
        public void Update( float deltaY )
        {
            screenpos.Y += deltaY;
            screenpos.Y = screenpos.Y % mytexture.Height;
        }



        /// <summary>
        /// called as part of Draw() in game
        /// </summary>
        public void Draw( SpriteBatch batch )
        {
            // Draw the texture, if it is still onscreen.
            if (screenpos.Y < screenheight)
            {
                batch.Draw( mytexture, screenpos, null,
                     Color.White, 0, origin, 1, SpriteEffects.None, 0f );
            }


            // Draw the texture a second time, behind the first,
            // to create the scrolling illusion.
            batch.Draw( mytexture, screenpos - texturesize, null,
                 Color.White, 0, origin, 1, SpriteEffects.None, 0f );
        }

    }

}
