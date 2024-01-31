using System;
using System.Reflection.Metadata;
using System.Numerics;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using particlesimulator.logic;

namespace particlesimulator.logic {
    public class Particle {

        private Vector2 position;
        private Vector2 velocity;
        private SFML.Graphics.Color particle_color;

        RectangleShape rect = new RectangleShape(new Vector2f(1, 1));

        public Particle(int screenWidth, int screenHeight, SFML.Graphics.Color color) {
            Random random = new Random();
            
            //position = pos;
            //velocity = vel;
            particle_color = color;

            position.X = random.Next(0, screenWidth-1);
            position.Y = random.Next(0, screenHeight-1);

            velocity.X = random.Next(-100, 100) / 100.0f;
            velocity.Y = random.Next(-100, 100) / 100.0f;
        }

        private float getDist(Vector2 mousePos) {
            float dx = position.X - mousePos.X;
            float dy = position.Y - mousePos.Y;

            return (float)Math.Sqrt((dx*dx) + (dy*dy));
        }

        private Vector2 getNormal(Vector2 otherPos) {
            float dist = getDist(otherPos);

            if(dist == 0.0f) {
                dist = 1;
            }

            float dx = position.X - otherPos.X;
            float dy = position.Y - otherPos.Y;

            Vector2 normal = new Vector2();
            normal.X = dx*(1/dist);
            normal.Y = dy*(1/dist);

            return normal;
        }


        public void Attract(Vector2 posToAttract, float multiplier) {
            float dist = Math.Max((float)getDist(posToAttract), 0.5f);
            Vector2 normal = getNormal(posToAttract);

            velocity.X -= normal.X/dist;
            velocity.Y -= normal.Y/dist;
        }

        public void doFriction(float amount) {
            velocity.X *= amount;
            velocity.Y *= amount;
        }

        public void MoveParticle(int screenWidth, int screenHeight) {
            position.X += velocity.X;
            position.Y += velocity.Y;

            if(position.X < 0) {
                position.X += screenWidth;
            }
            if(position.X > screenWidth) {
                position.X -= screenWidth;
            }
            if(position.Y < 0) {
                position.Y += screenHeight;
            }
            if(position.Y > screenHeight) {
                position.Y -= screenHeight;
            }
            
        }





        public void DrawPixel(RenderWindow display) {

            float x = position.X;
            float y = position.Y;
            Color color = particle_color;

            rect.Position = new Vector2f(x, y);
            //rect.Size = new Vector2f(1, 1);
            rect.FillColor = color;

            display.Draw(rect);
        }
    }
}