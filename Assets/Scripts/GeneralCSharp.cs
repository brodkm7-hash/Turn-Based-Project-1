using System.Collections.Generic;
using UnityEngine;

public class GeneralCSharp : MonoBehaviour
{
    public Mammal tiger; 
    void Start()
    {
        tiger = new Mammal();
        tiger.printName();
    }

    void Update()
    {

    }
}

public class Animal
{
    public string bloodType;
    public string name;
    public bool laysEggs;
    public Animal Whinny;

    protected void desc()
    {
        Debug.Log("Hello everyone, my name is " + name + ". My blood type is " + bloodType + ". Can I lay eggs? " + laysEggs);
    }

    public bool GetLaysEggs()
    {
        return laysEggs;
    }

    public Animal getAnimal()
    {
        return Whinny;
    }
    public void SetLaysEggs(bool value)
    {
        laysEggs = value;
    }
}
public class Mammal : Animal
{
        public void printName()
        {
            name = "tiger";
            Debug.Log(name);
            bloodType = "AB";
            SetLaysEggs(false);
            desc();
        }
}