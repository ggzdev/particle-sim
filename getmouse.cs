using System;
using System.Reflection.Metadata;
using System.Numerics;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace particlesimulator.logic {
    public static class MousePosHandler {

        private static bool inValidRange = false;
        private static float lastX = 0;
        private static float lastY = 0;


        public static Vector2 GetMousePosition(RenderWindow display, int screenWidth, int screenHeight) {
            Vector2i pixelPos = Mouse.GetPosition(display);
            Vector2f worldSpace = display.MapPixelToCoords(pixelPos);
            Vector2 mousePos = new Vector2(worldSpace.X, worldSpace.Y);

            if(inValidRange) {
                lastX = mousePos.X;
                lastY = mousePos.Y;
            }

            if(mousePos.X < 0 || mousePos.X > screenWidth || mousePos.Y < 0 || mousePos.Y > screenHeight) {
                inValidRange = false;
            }
            else {
                inValidRange = true;
            }

            
            Vector2 mousePosFinal = new Vector2(lastX, lastY);
            return mousePosFinal;
        }
    }
}