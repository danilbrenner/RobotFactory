using Microsoft.Practices.Unity;
using RobotFactory.Robot.Parts;

namespace RobotFactory.Producers
{
    public static class ProducersBootstraper
    {
        public static IUnityContainer Bootstrap()
        {
            return new UnityContainer()
                .RegisterType<IProducer<Arms>, GenericProducer<Arms>>(new InjectionConstructor("arm", 100))
                .RegisterType<IProducer<Boby>, GenericProducer<Boby>>(new InjectionConstructor("boby", 500))
                .RegisterType<IProducer<Head>, GenericProducer<Head>>(new InjectionConstructor("head", 800))
                .RegisterType<IProducer<Legs>, GenericProducer<Legs>>(new InjectionConstructor("leg", 200))
                ;
        }
    }
}
