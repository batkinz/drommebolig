using StructureMap;
using StructureMap.Pipeline;

public class StructuremapRegistry : Registry
{
    public StructuremapRegistry()
    {
        // For<IMessagingService>().Use<StructuremapMessagingService>();
    }
}