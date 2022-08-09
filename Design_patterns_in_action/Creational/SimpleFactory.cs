namespace Design_patterns_in_action.Creational;

public interface IDoor
{
    int GetHeight();
    int GetWidth();
    void GetDescription();
}
class IronDoor : IDoor
{
    public void GetDescription()
    {
        Console.WriteLine("I am a iron door");
    }

    public int GetHeight()
    {
        throw new NotImplementedException();
    }

    public int GetWidth()
    {
        throw new NotImplementedException();
    }
}
public class WoodenDoor : IDoor
{
    private int Height { get; }
    private int Width { get; }

    public WoodenDoor(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public WoodenDoor()
    {
    }

    public int GetHeight() => Height;

    public int GetWidth() => Width;

    public void GetDescription() => Console.WriteLine("I am a wooden door");
}

public static class DoorFactory
{
    public static IDoor MakeDoor(int height, int width)
    {
        return new WoodenDoor(height, width);
    }
}