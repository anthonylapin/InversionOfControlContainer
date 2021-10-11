namespace InversionOfControlContainer.Services
{
    public class CircleService
    {
        private readonly IRenderer _renderer;
        
        public CircleService(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public void Draw(float radius)
        {
            _renderer.RenderCircle(radius);
        }
    }
}