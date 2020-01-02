using System;
using System.Collections.Generic;
using System.Text;

namespace DoFactoryDesignPatternsAbstractFactory
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Abstract Factory Design Pattern.
    /// </summary>
    /// <param name="args"></param>

    public class AbstractClassVersion
    {
            /// <summary>
            /// Entry point into console application.
            /// </summary>
            /// <param name="args"></param>
            public AbstractClassVersion()
            {

                Console.WriteLine("Hello World!");
                ContinentFactory africa = new AfricaFactory();
                AnimalWorld world = new AnimalWorld(africa);
                world.RunFoodChain();

                Console.WriteLine("Hello World!");
                ContinentFactory america = new AmericaFactory();
                world = new AnimalWorld(america);
                world.RunFoodChain();
            }
    }

        /// <summary>
        /// The 'AbstractFactory' abstract class.
        /// </summary>
        abstract class ContinentFactory
        {
            public abstract Herbivore CreateHerbivore();
            public abstract Carnivore CreateCarvinore();

            public abstract HerCar CreateHerCar();

        }

        class AfricaFactory : ContinentFactory
        {
            public override Carnivore CreateCarvinore()
            {
                return new Lion();
            }

            public override Herbivore CreateHerbivore()
            {
                return new Wildebeest();
            }

            public override HerCar CreateHerCar()
            {
                return new Vulture();
            }
        }

        class AmericaFactory : ContinentFactory
        {
            public override Carnivore CreateCarvinore()
            {
                return new Wolf();
            }

            public override Herbivore CreateHerbivore()
            {
                return new Bison();
            }

           public override HerCar CreateHerCar()
            {
                return new Bear();
            }

        }

        abstract class Herbivore
        {

        }

        abstract class Carnivore
        {
            public abstract void Eat(Herbivore h);
        }

        abstract class HerCar : Carnivore
        {
            public abstract void Eat(Carnivore c);
        }

        class Wildebeest : Herbivore
        {

        }

        class Lion : Carnivore
        {
            public override void Eat(Herbivore h)
            {
                Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
            }
        }

        class Vulture : HerCar
        {
            public override void Eat(Carnivore c)
            {
                Console.WriteLine(this.GetType().Name + " eats this Carnivore " + c.GetType().Name);
            }

            public override void Eat(Herbivore h)
            {
                Console.WriteLine(this.GetType().Name + " eats this Herbivore " + h.GetType().Name);
            }
        }

        class Bison : Herbivore
        {

        }

        class Wolf : Carnivore
        {
            public override void Eat(Herbivore h)
            {
                Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
            }
        }

        class Bear : HerCar
        {
            public override void Eat(Carnivore c)
            {
                Console.WriteLine(this.GetType().Name + " eats this Carnivore " + c.GetType().Name);
            }

            public override void Eat(Herbivore h)
            {
                Console.WriteLine(this.GetType().Name + " eats this Herbivore " + h.GetType().Name);
            }
        }

    class AnimalWorld
        {
            private Herbivore _herbivore;
            private Carnivore _carnivore;
            private HerCar _herCar;
            // Constructor
            public AnimalWorld(ContinentFactory factory)
            {
                _carnivore = factory.CreateCarvinore();
                _herbivore = factory.CreateHerbivore();
                _herCar = factory.CreateHerCar();
            }

            public void RunFoodChain()
            {
                _carnivore.Eat(_herbivore);
                _herCar.Eat(_herbivore);
                _herCar.Eat(_carnivore);
            }
        }

}

