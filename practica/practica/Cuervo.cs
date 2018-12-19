using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
namespace practica
{

    class Cuervo
    {
        Texture2D t2Cuervo;
        Rectangle recOriginal;
        Rectangle recFrame;
        Rectangle recPos;
        int curFramePosition;
        int frameTime = 0;
        public Cuervo(Texture2D textura, int originalWith, int originalHeight)
        {
            t2Cuervo = textura;
            recOriginal = new Rectangle(0, 0, originalWith, originalHeight);
            recPos = new Rectangle(400, 300, 97, 120);
            recFrame = new Rectangle();

        }
        public Cuervo(Texture2D textura, int With, int Height,int posX,int posY)
        {
            t2Cuervo = textura;
            recOriginal = new Rectangle(0, 0, 776, 120);
            recPos = new Rectangle(posX, posY, With, Height);
            recFrame = new Rectangle();

        }
        public Rectangle getRecPos()
        {
            return recPos;
        }

        public int getY()
        {
            return recPos.Y;
        }

        public int getX()
        {

            return recPos.X;
        }
        public void updateY(int h)
        {
            recPos.Y = recPos.Y + h;
        }

        public void updateX(int w)
        {
            recPos.X = recPos.X + w;
        }

        public void nextFrame(SpriteBatch spriteBatch)
        {
            if (recPos.X < 200 || recPos.Y>400) {
                frameTime = 0;   
            }

            if (frameTime == 0)
            {

                if (curFramePosition == 0)
                {

                    recFrame.X = 0;
                    recFrame.Y = 0;
                    recFrame.Height = 120;
                    recFrame.Width = 97;

                }
                if (curFramePosition == 1)
                {
                    recFrame.X = 97 * curFramePosition;
                    recFrame.Y = 0;
                    recFrame.Height = 120;
                    recFrame.Width = 97;
                }
                if (curFramePosition == 2)
                {
                    recFrame.X = 97 * curFramePosition;
                    recFrame.Y = 0;
                    recFrame.Height = 120;
                    recFrame.Width = 97;
                }
                if (curFramePosition == 3)
                {
                    recFrame.X = 97 * curFramePosition;
                    recFrame.Y = 0;
                    recFrame.Height = 120;
                    recFrame.Width = 97;
                }
                curFramePosition = curFramePosition + 1;
                if (curFramePosition == 4)
                {
                    curFramePosition = 0;
                }

            }

            //recPos.Width = 97;
            //recPos.Height= 120;

            recPos.Width = 48;
            recPos.Height = 60;
            spriteBatch.Draw(t2Cuervo, recPos, recFrame, Color.White);
            frameTime = frameTime + 1;
            if (frameTime == 8)
            {
                frameTime = 0;
            }

        }



    }
}
