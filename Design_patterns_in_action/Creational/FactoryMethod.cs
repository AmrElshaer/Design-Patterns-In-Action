namespace Design_patterns_in_action.Creational;

internal interface IInterviewer
{
    void AskQuestions();
}

internal class Developer : IInterviewer
{
    public void AskQuestions()
    {
        Console.WriteLine("Asking about design patterns!");
    }
}

internal class CommunityExecutive : IInterviewer
{
    public void AskQuestions()
    {
        Console.WriteLine("Asking about community building!");
    }
}
//the definition of the Factory Method design pattern, which is when a superclass(HiringManager) provides an interface for creating objects(MakeInterviewerquestion method), but allows subclasses(Development,Marketing) to decide which class to instantiate. In this case, the HiringManager class provides a MakeInterviewer method that returns an instance of an IPaymentMethod interface, and delegates the responsibility of creating the appropriate IInterviewer implementation to its concrete subclasses, MarketingManager and DevelopmentManager.
internal abstract class HiringManager
{
    // Factory method
    protected abstract IInterviewer MakeInterviewer();

    public void TakeInterview()
    {
        var interviewer = MakeInterviewer();
        interviewer.AskQuestions();
    }
}

internal class DevelopmentManager : HiringManager
{
    protected override IInterviewer MakeInterviewer()
    {
        return new Developer();
    }
}

internal class MarketingManager : HiringManager
{
    protected override IInterviewer MakeInterviewer()
    {
        return new CommunityExecutive();
    }
}
