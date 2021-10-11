using InversionOfControlContainer.Services;

namespace InversionOfControlContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            
            container.RegisterService<IRenderer, ConsoleRenderer>();
            container.RegisterService<CircleService>();

            var circleService = container.ResolveService<CircleService>();
            
            circleService.Draw(5);
        }
    }
}