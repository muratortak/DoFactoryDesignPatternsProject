using System;
using DoFactoryDesignPatternsAbstractFactory;

namespace DoFactoryDesignPatterns
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Abstract Factory Design Pattern.
    /// </summary>
    /// <param name="args"></param>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //Console.WriteLine("This is the Abstract Class World");
            //// Abstract Class Version of the Pattern.
            //AbstractClassVersion abstractClassVersion = new AbstractClassVersion();

            //Console.WriteLine("This is the Interface World");
            //// Interface Version of the Pattern.
            //Console.WriteLine("");
            //Console.WriteLine("Hello World!");
            //IContentFactory africa = new AfricaFactory();
            //AnimalWorld world = new AnimalWorld(africa);
            //world.RunFoodChain();

            //Console.WriteLine("");
            //Console.WriteLine("Hello World!");
            //IContentFactory america = new AmericaFactory();
            //world = new AnimalWorld(america);
            //world.RunFoodChain();

            // Builder Design Pattern
            //BuilderDesign bd = new BuilderDesign();

            // Builder Design Pattern Real World
            BuilderDesignRealWorld builderEx = new BuilderDesignRealWorld();
        }
    }

    /// <summary>
    /// The 'AbstractFactory' abstract class.
    /// </summary>
    interface IContentFactory
    {
        IHerbivore CreateHerbivore();
        ICarnivore CreateCarvinore();

        IHerbCarv CreateHerbCarv();
    }

    class AfricaFactory : IContentFactory
    {
        public ICarnivore CreateCarvinore()
        {
            return new Lion();
        }

        public IHerbivore CreateHerbivore()
        {
            return new Wildebeest(); 
        }

        public IHerbCarv CreateHerbCarv()
        {
            return new Vulture();
        }
    }

    class AmericaFactory : IContentFactory
    {
        public ICarnivore CreateCarvinore()
        {
            return new Wolf();
        }

        public IHerbivore CreateHerbivore()
        {
            return new Bison(); 
        }

        public IHerbCarv CreateHerbCarv()
        {
            return new Bear();
        }
    }

    interface IHerbivore
    {

    } 

    interface ICarnivore
    {
        void Eat(IHerbivore h);
    }

    interface IHerbCarv : IHerbivore, ICarnivore
    {
        void Eat(ICarnivore c);
    }

    class Wildebeest : IHerbivore
    {
        
    }

    class Lion : ICarnivore
    {
        public void Eat(IHerbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class Bison : IHerbivore
    {

    }

    class Vulture : IHerbCarv
    {

        void ICarnivore.Eat(IHerbivore h)
        {
            Console.Write(this.GetType().Name + " eats this herbivore " + h.GetType().Name);
        }


        void IHerbCarv.Eat(ICarnivore c)
        {
            Console.Write(" eats this carnivore " + c.GetType().Name);
        }

    }
    class Bear : IHerbCarv
    {

        void ICarnivore.Eat(IHerbivore h)
        {
            Console.Write(this.GetType().Name + " eats this herbivore " + h.GetType().Name);
        }


        void IHerbCarv.Eat(ICarnivore c)
        {
            Console.Write(" eats this carnivore " + c.GetType().Name);
        }

    }

    class Wolf : ICarnivore
    {
        public void Eat(IHerbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

    class AnimalWorld
    {
        private IHerbivore _herbivore;
        private ICarnivore _carnivore;
        private IHerbCarv _herbCarv;

        // Constructor
        public AnimalWorld(IContentFactory factory)
        {
            _carnivore = factory.CreateCarvinore();
            _herbivore = factory.CreateHerbivore();
            _herbCarv = factory.CreateHerbCarv();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
            _herbCarv.Eat(_herbivore);
            _herbCarv.Eat(_carnivore);

        }
    }


}
