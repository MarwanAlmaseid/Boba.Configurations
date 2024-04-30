namespace Boba.Configurations.Test;

public class AppDomainTypeFinderTests
{
    [Fact]
    public void FindClassesOfType_Should_Return_Correct_Assignable_Types()
    {
        // Arrange
        var typeFinder = new AppDomainTypeFinder();
        var expectedAssignableType = typeof(IConfig); // Replace with your actual assignable type

        // Act
        var foundTypes = typeFinder.FindClassesOfType(expectedAssignableType);

        // Assert
        Assert.NotNull(foundTypes);
        Assert.NotEmpty(foundTypes);

        // Verify that all found types are assignable to the expected type
        foreach (var type in foundTypes)
        {
            Assert.True(expectedAssignableType.IsAssignableFrom(type));
        }
    }

    [Fact]
    public void FindClassesOfType_Returns_Correct_Types()
    {
        // Arrange
        var finder = new AppDomainTypeFinder();
        var expectedType = typeof(IService); // Change this to your expected type
        var expectedConcreteType = typeof(ConcreteService); // Change this to your expected concrete type

        // Act
        var types = finder.FindClassesOfType(expectedType);

        // Assert
        Assert.NotNull(types);
        Assert.Contains(expectedConcreteType, types);
    }

    [Fact]
    public void FindClassesOfType_Returns_Concrete_Only()
    {
        // Arrange
        var finder = new AppDomainTypeFinder();
        var expectedType = typeof(IService); // Change this to your expected type

        // Act
        var types = finder.FindClassesOfType(expectedType, onlyConcreteClasses: true);

        // Assert
        Assert.NotNull(types);
        Assert.All(types, type => Assert.True(type.IsClass && !type.IsAbstract));
    }

    [Fact]
    public void FindClassesOfType_Returns_All_Types()
    {
        // Arrange
        var finder = new AppDomainTypeFinder();
        var expectedType = typeof(IService); // Change this to your expected type

        // Act
        var types = finder.FindClassesOfType(expectedType, onlyConcreteClasses: false);

        // Assert
        Assert.NotNull(types);
        Assert.All(types, type => Assert.True(expectedType.IsAssignableFrom(type)));
    }

    // Example interfaces and classes for testing
    interface IService { }
    class ConcreteService : IService { }
    abstract class AbstractService : IService { }
}
