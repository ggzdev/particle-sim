using System;
using System.Reflection.Metadata;
using System.Numerics;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using particlesimulator.logic;


namespace particlesimulator {

    public class Program {

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vkey);


        // ------------------------------------------------------------ EDIT THESE VALUES TO CHANGE THE WINDOW SETITNGS
        private static bool windowState = true;
        private static int window_windowWidth = 800;
        private static int window_windowHeight = 800;
        private static int window_maxFPS = 60;
        private static int physics_particleCount = 50000;
        // ------------------------------------------------------------

        private static Particle[] particles = new Particle[physics_particleCount+1];

        private static void sfmlHandler() {
            VideoMode screen = new VideoMode((uint)window_windowWidth, (uint)window_windowHeight);
            RenderWindow display = new RenderWindow(screen, "Particle Simulator - Build 0.0.1 alpha");
            display.SetFramerateLimit((uint)window_maxFPS);


            //instantiate particles
            for(int p = 0; p < physics_particleCount; p++) {
                particles[p] = new Particle(window_windowWidth, window_windowHeight, Color.White);
            }
            

            while(true) {
                if(!windowState) {
                    break;
                }
                if(GetAsyncKeyState(0x1B) < 0) {
                    windowState = false;
                    //Thread.Sleep(50);
                }

                // get mouse position
                Vector2 mousePos = MousePosHandler.GetMousePosition(display, window_windowWidth, window_windowHeight);

                display.DispatchEvents();
                display.Clear(SFML.Graphics.Color.Black);

                // --- logic
                for(int i = 0; i < physics_particleCount; i++) {
                    particles[i].Attract(mousePos, 1);
                    particles[i].doFriction(0.99f);
                    particles[i].MoveParticle(window_windowWidth, window_windowHeight);
                }

                // --- rendering
                for(int i = 0; i < physics_particleCount; i++) {
                    particles[i].DrawPixel(display);
                }





                display.Display();
            }
            Environment.Exit(0);

        }


        private static void Main(string[] args) {
            Thread sfml = new Thread(() => sfmlHandler());
            sfml.Start();
        }
    }
}