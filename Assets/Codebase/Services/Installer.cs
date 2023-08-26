using Codebase.StaticData;
using Zenject;

namespace Codebase.Services
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<IPlanetaryObjectCreator>().To<PlanetaryObjectCreator>().AsSingle();
            Container.Bind<IPlanetarySystemFactory>().To<PlanetarySystemFactory>().AsSingle();
        }
    }
}