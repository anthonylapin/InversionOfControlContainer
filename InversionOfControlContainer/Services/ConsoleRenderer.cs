using System;

namespace InversionOfControlContainer.Services
{
    public class ConsoleRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }
}