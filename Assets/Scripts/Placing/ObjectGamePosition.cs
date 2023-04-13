public class ObjectGamePosition
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Health { get; set; }
    public ObjectGamePosition(string name, int x, int y, int health)
    {
        Name = name;
        X = x;
        Y = y;
        Health = health;
    }
}