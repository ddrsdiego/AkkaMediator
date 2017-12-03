using Castle.MicroKernel;

namespace ConsoleApp.IoC
{
    public static class FrameworkContainer
    {
        public static void RegisterFrameworkContainer(this IKernel container)
        {
            container.AddFacility(new MediatorFacility());
        }
    }
}
