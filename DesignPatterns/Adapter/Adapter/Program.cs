﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.dofactory.com/net/adapter-design-pattern

namespace Adapter.RealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //non-adapted chemical compound
            Compound unknown = new Compound("Unknown");
            unknown.Display();

            // adapted 
            Compound water = new RichCompound("Water");
            water.Display();
            Compound benzene = new RichCompound("benzene");
            benzene.Display();
            Compound ethanol = new RichCompound("ethanol");
            ethanol.Display();

            Console.ReadKey();

        }

        // Adapter class
        class RichCompound : Compound
        {
            private ChemicalDatabank _bank;

            public RichCompound(string name) : base(name) { }

            public override void Display()
            {
                // adatpee
                _bank = new ChemicalDatabank();

                _boilingPoint = _bank.GetCriticalPoint(_chemical, "B");
                _meltingPoint = _bank.GetCriticalPoint(_chemical, "M");
                _molecularWeight = _bank.GetMolecularWeight(_chemical);
                _molecularFormula = _bank.GetMolecularStructure(_chemical);

                base.Display();
                Console.WriteLine(" Formula: {0}", _molecularFormula);          
                Console.WriteLine(" Weight : {0}", _molecularWeight);
                Console.WriteLine(" Melting Pt: {0}", _meltingPoint);
                Console.WriteLine(" Boiling Pt: {0}", _boilingPoint);
            }
        }

        // Target Class
        class Compound
        {
            protected string _chemical;
            protected float _boilingPoint;
            protected float _meltingPoint;
            protected double _molecularWeight;
            protected string _molecularFormula;

            public Compound(string chemical)
            {
                this._chemical = chemical;
            }

            public virtual void Display()
            {
                Console.WriteLine("compound {0}",_chemical);
            }
        }

        /// The 'Adaptee' class
        class ChemicalDatabank{
            // The databank 'legacy API'
            public float GetCriticalPoint(string compound, string point){
                // Melting Point
                if (point == "M"){
                    switch (compound.ToLower()){
                        case "water": return 0.0f;
                        case "benzene": return 5.5f;
                        case "ethanol": return -114.1f;
                        default: return 0f;
                    }
                } // Boiling Point
                else{
                    switch (compound.ToLower()){
                        case "water": return 100.0f;
                        case "benzene": return 80.1f;
                        case "ethanol": return 78.3f;
                        default: return 0f;
                    }
                }
            }
            public string GetMolecularStructure(string compound){
                switch (compound.ToLower()){
                    case "water": return "H20";
                    case "benzene": return "C6H6";
                    case "ethanol": return "C2H5OH";
                    default: return "";
                }
            }
            
            public double GetMolecularWeight(string compound){
                switch (compound.ToLower())
                {
                    case "water": return 18.015;
                    case "benzene": return 78.1134;
                    case "ethanol": return 46.0688;
                    default: return 0d;
                }
            }
        }
}

namespace Adapter.Structural
{
    class Program
    {
        static void Main(string[] args)
        {

            Target target = new Adapter();
            target.Request();

            Console.ReadKey();
        }

        class Target
        {
            public virtual void Request()
            {
                Console.WriteLine("Called Target Request()");
            }
        }

        class Adapter : Target
        {
            private Adaptee _adaptee = new Adaptee();

            public override void Request()
            {
                _adaptee.SpecificRequest();
            }
        }

        class Adaptee
        {
            public void SpecificRequest()
            {
                Console.WriteLine("Called SpecificRequest()");
            }
        }
    }
}