using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    abstract public class Component
    {
        protected string name;
        public Component(string name)
        { this.name = name; }
        abstract public void Add(Component obj);
        abstract public void Remove(Component obj);
        abstract public void Display(int depth);
    }
    public class Composite:Component
    {
        List<Component> components;
        public Composite(string name):base(name)
        {
            components = new List<Component>();
        }
        public override void Add(Component obj)
        {
            components.Add(obj);
        }
        public override void Remove(Component obj)
        {
            components.Remove(obj);
        }
        public override void Display(int depth)
        {
            string s = new string('-',depth);
            Console.WriteLine(s + name);
            foreach(Component obj in components)
            {
                obj.Display(depth+2);
            }
        }
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name) { }
        public override void Add(Component obj)
        {
            Console.WriteLine("Can not add");
        }
        public override void Remove(Component obj)
        {
            Console.WriteLine("Can not remove");
        }
        public override void Display(int depth)
        {
            string s = new string('-',depth);
            Console.WriteLine(s + name);
        }
    }

    public class ReceptionRoom : Composite
    {
        string colour;
        public ReceptionRoom(string name, string colour ) : base(name)
        {
            this.colour = colour;
        }
    }

    public class PC : Composite
    {
        CPU cpu;
        GPU gpu;
        RAM ram;
        HDD hdd;
        public PC(string name, CPU cpu, GPU gpu, RAM ram, HDD hdd):base(name)
        {
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.hdd = hdd;
        }
    }
    public class CPU : Leaf
    {
        int cores;
        int frequency;
        string socket;
        public CPU(string name,int cores, int frequency, string socket):base(name)
        {
            this.cores = cores;
            this.frequency = frequency;
            this.socket = socket;
        }
    }
    public class GPU : Leaf
    {
        int frequency;
        string PCItype;
        public GPU(string name, int frequency, string PCItype):base(name) 
        {
            this.frequency = frequency;
            this.PCItype = PCItype;
        }
    }
    public class RAM : Leaf
    {
        int memoryValue;
        int frequency;
        string DDRtype;
        public RAM(string name,int memoryValue, int frequency, string DDRtype):base (name)
        {
            this.memoryValue = memoryValue;
            this.frequency = frequency;
            this.DDRtype = DDRtype;
        }
    }
    public class HDD : Leaf
    {
        int memoryValue;
        int rotationSpeed;
        string SATAtype;
        string formFactor;
        public HDD(string name,int memoryValue, int rotationSpeed, string SATAtype, string formFactor):base(name) 
        {
            this.memoryValue = memoryValue;
            this.rotationSpeed = rotationSpeed;
            this.SATAtype = SATAtype;
            this.formFactor = formFactor;
        }
    }
}
