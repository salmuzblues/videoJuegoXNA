using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
namespace practica
{

    class Aguila
    {
        Texture2D t2Aguila;
        Rectangle recOriginal;
        Rectangle recFrame;
        Rectangle recPos;
        int curFramePosition;
        int frameTime = 0;
        public int velocidad;
        public bool esColisionable = true;
        public int orginaheight = 0;

        Random rnd;
        public Aguila(Texture2D textura, int originalWith, int originalHeight)
        {
            t2Aguila = textura;
            recOriginal = new Rectangle(0, 0, originalWith, originalHeight);
            recPos = new Rectangle();
            recPos.X = 1150 - 80;
            recPos.Y = 250;
            recFrame = new Rectangle();
            rnd = new Random();
        }

        public Aguila(Texture2D textura, int initialX, int initialY, int originalWith, int originalHeight)
        {
            t2Aguila = textura;
            recOriginal = new Rectangle(0, 0, originalWith, originalHeight);
            recPos = new Rectangle();
            recPos.X = initialX;
            recPos.Y = initialY;
            recFrame = new Rectangle();
            rnd = new Random();
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
        public void setHeight(int h)
        {
            recPos.Y = h;
        }

        public void updateX(int w)
        {

            recPos.X = recPos.X + w;
        }

        public void nextFrame(SpriteBatch spriteBatch)
        {

            if (frameTime == 0)
            {

                if (curFramePosition == 0)
                {

                    recFrame.X = 0;
                    recFrame.Y = 0;
                    recFrame.Height = 150;
                    recFrame.Width = 73;

                }
                if (curFramePosition == 1)
                {
                    recFrame.X = 73;
                    recFrame.Y = 0;
                    recFrame.Height = 150;
                    recFrame.Width = 78;
                }
                if (curFramePosition == 2)
                {
                    recFrame.X = 148;
                    recFrame.Y = 0;
                    recFrame.Height = 150;
                    recFrame.Width = 77;
                }
                if (curFramePosition == 3)
                {
                    recFrame.X = 225;
                    recFrame.Y = 0;
                    recFrame.Height = 150;
                    recFrame.Width = 75;
                }
                curFramePosition = curFramePosition + 1;
                if (curFramePosition == 4)
                {
                    curFramePosition = 0;
                }

            }

            recPos.Width = 97;
            recPos.Height = 120;
            if (esColisionable == false)
            {
                recPos.Y = recPos.Y + 8;
            }
            spriteBatch.Draw(t2Aguila, recPos, recFrame, Color.White);
            frameTime = frameTime + 1;
            if (!esColisionable)
            {
                frameTime = 0;
            }
            else
            {

                if (frameTime == 3)
                {
                    frameTime = 0;
                }
            }


        }



    }
}
