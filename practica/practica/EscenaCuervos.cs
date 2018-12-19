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
    
    class EscenaCuervos
    {

        List<Cuervo> cuervos;

        public EscenaCuervos(Texture2D textura) {
            cuervos = new List<Cuervo>();
            
            
            Cuervo cuervo1 = new Cuervo(textura,12,15,1000, 200);
            Cuervo cuervo2 = new Cuervo(textura, 12, 15, 1000, 300);
            Cuervo cuervo3 = new Cuervo(textura, 12, 15, 1000, 400);

            cuervos.Add(cuervo1);
            cuervos.Add(cuervo2);
            cuervos.Add(cuervo3);
        }


        public void nextFrame(SpriteBatch spriteBatch) { 
        
            foreach(Cuervo cuervo in cuervos){
            
                cuervo.nextFrame(spriteBatch); 
            }
        }
    }
}
