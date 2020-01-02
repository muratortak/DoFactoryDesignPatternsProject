using System;
using System.Collections.Generic;
using System.Text;

namespace DoFactoryDesignPatternsAbstractFactory
{
    public class BuilderDesignRealWorld
    {
        public BuilderDesignRealWorld()
        {

            VehicleBuilder builder;
            Shop director = new Shop();

            builder = new MotorCycleBuilder();
            director.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            director.Construct(builder);
            builder.Vehicle.Show();

            builder = new ScooterBuilder();
            director.Construct(builder);
            builder.Vehicle.Show();

        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class VehicleBuilder
    {
        protected Vehicle _vehicle;

        // Gets vehicle instance
        public Vehicle Vehicle
        {
            get { return _vehicle; }
        }

        // Abstract Build methods
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class.
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            _vehicle = new Vehicle("MotorCycle");
        }
        public override void BuildDoors()
        {
            _vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            _vehicle["engine"] = "500 cc";
        }

        public override void BuildFrame()
        {
            _vehicle["wheels"] = "2";
        }

        public override void BuildWheels()
        {
            _vehicle["doors"] = "0";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class.
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            _vehicle = new Vehicle("Car");
        }
        public override void BuildDoors()
        {
            _vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            _vehicle["engine"] = "2500 cc";
        }

        public override void BuildFrame()
        {
            _vehicle["wheels"] = "4";
        }

        public override void BuildWheels()
        {
            _vehicle["doors"] = "4";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder3' class.
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            _vehicle = new Vehicle("Scooter");
        }
        public override void BuildDoors()
        {
            _vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            _vehicle["engine"] = "50 cc";
        }

        public override void BuildFrame()
        {
            _vehicle["wheels"] = "2";
        }

        public override void BuildWheels()
        {
            _vehicle["doors"] = "0";
        }
    }

    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();

        //Constructor
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }

        // Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels : {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }
}
