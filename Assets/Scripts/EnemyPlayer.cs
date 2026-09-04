using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{
    public Entity slime;
    void Start()
    {
        slime = new Entity();
        slime.printName();
    }

    void Update()
    {

    }
}

public class Characters
{
    public string Health;
    public string Name;
    public bool isAlive;

    protected void test()
    {
        Debug.Log("This is a " + Name + ". It has " + Health + "hp. Am I alive? " + isAlive);
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }
    public void IsAlive(bool value)
    {
        isAlive = value;
    }
}
public class Entity : Characters
{
    public void printName()
    {
        Name = "slime";
        Health = "30";
        IsAlive(false);
        test();
    }
}