using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace practica
{
    class Controlador
    {
        List<Aguila> aguilas;
        int controlCreacion = 0;
        Texture2D texturaAguila;
        public bool regresar = true;
        Random rnd;

        public Controlador()
        {
            aguilas = new List<Aguila>();

            rnd = new Random();


        }

        List<int> velocidades = new List<int>();
        private int getVeocidades()
        {

            int numero = 0;
            do
            {

                if (velocidades.Count == 3)
                {
                    velocidades.Clear();
                }
                numero = rnd.Next(2, 5);

            } while (velocidades.Contains(numero));

            velocidades.Add(numero);

            return numero;

        }


        List<int> alturas = new List<int>();
        private int getPosition()
        {

            int numero = 0;
            do
            {

                if (alturas.Count == 4)
                {
                    alturas.Clear();
                }
                numero = rnd.Next(1, 5);

            } while (alturas.Contains(numero));

            alturas.Add(numero);

            return numero;

        }
        public void crearAguila(Texture2D textura)
        {
            //iniciar en diferentes alturas
            texturaAguila = textura;
            if (aguilas.Count < 4)
            {
                int h1 = 120 * getPosition();
                Aguila aguila = new Aguila(texturaAguila, 1150 - 80, h1, 300, 150);
                aguila.orginaheight = h1;
                aguila.velocidad = getVeocidades();
                aguilas.Add(aguila);

                int h2 = 120 * getPosition();
                Aguila aguila2 = new Aguila(texturaAguila, 1150 - 80, h2, 300, 150);
                aguila2.orginaheight = h2;
                aguila2.velocidad = getVeocidades();
                aguilas.Add(aguila2);


                int h3 = 120 * getPosition();
                Aguila aguila3 = new Aguila(texturaAguila, 1150 - 80, h3, 300, 150);
                aguila3.orginaheight = h3;
                aguila3.velocidad = getVeocidades();
                aguilas.Add(aguila3);


                int h4 = 120 * getPosition();
                Aguila aguila4 = new Aguila(texturaAguila, 1150 - 80, h4, 300, 150);
                aguila4.orginaheight = h4;
                aguila4.velocidad = getVeocidades();
                aguilas.Add(aguila4);
            }

        }

        public void actualizarPosicion()
        {
            foreach (Aguila aguila in aguilas)
            {
                if (regresar) {
                    if (aguila.getX() <= -80)
                    {
                        aguila.velocidad = getVeocidades();
                        aguila.esColisionable = true;
                        aguila.setHeight(aguila.orginaheight);
                        aguila.updateX(1150);
                    }
                }
                
                aguila.updateX(-1 * aguila.velocidad);
            }

            //diferentes veolocidad y ruta
        }

        public bool checkCollision(Cuervo cuervo)
        {
            bool intersecta = false;
            foreach (Aguila aguila in aguilas)
            {
                if (aguila.esColisionable)
                {

                    intersecta = aguila.getRecPos().Intersects(cuervo.getRecPos());
                    if (intersecta)
                    {
                        aguila.esColisionable = false;
                        return intersecta;
                    }
                }


            }
            return intersecta;
        }

        public void drawAguilas(SpriteBatch spriteBatch)
        {

            foreach (Aguila aguila in aguilas)
            {

                aguila.nextFrame(spriteBatch);
            }
        }
    }
}
