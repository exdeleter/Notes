using JetBrains.Annotations;
using Moq;
using Notes.Infrastructure.Abstractions;
using Xunit;

namespace Tests;

/// <summary> Тесты репозитория. </summary>
[TestSubject(typeof(IRepository<Entity, EntityDto>))]
public class RepositoryTest
{
    private readonly Mock<IRepository<Entity,EntityDto>> _repositoryMock = new();
    private readonly CancellationToken _ct = new();

    [Fact]
    public async Task GetEntity()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var name = "Тестирование";

        _repositoryMock.Setup(r => r.GetAsync( guid, _ct))
            .ReturnsAsync(new Entity { Id = guid, Name = name});

        var controller = new GetEntityByIdHandler(_repositoryMock.Object);

        // Act
        var entity = await controller.Handle(guid, _ct);

        // Assert
        _repositoryMock.Verify(r => r.GetAsync(guid, _ct));
        Assert.Equal(name, entity.Name);
    }
    
    [Fact]
    public async Task GetNullEntity()
    {
        // Arrange
        var guid = Guid.NewGuid();

        _repositoryMock.Setup(r => r.GetAsync(guid, _ct))
            .ReturnsAsync((Entity)null);

        var controller = new GetEntityByIdHandler(_repositoryMock.Object);

        // Act
        var entity = await controller.Handle(guid, _ct);

        // Assert
        _repositoryMock.Verify(r => r.GetAsync(guid, _ct), Times.Once);
        Assert.Null(entity); 
    }
    
    [Fact]
    public async Task GetAllEntity()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetAllAsync(_ct))
            .ReturnsAsync(new List<Entity>
            {
                new() { Id = Guid.NewGuid(), Name = "Name1" },
                new() { Id = Guid.NewGuid(), Name = "Name2" }
            });

        var controller = new GetEntitiesHandler(_repositoryMock.Object);

        // Act
        var entities = await controller.Handle(_ct);

        // Assert
        _repositoryMock.Verify(r => r.GetAllAsync(_ct));
        Assert.Equal(2, entities.Count);
    }
    
    [Fact]
    public async Task UpdateEntity()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var dto = new EntityDto()
        {
            Id = guid,
            Name = "Наименование"
        };

        _repositoryMock.Setup(r => r.UpdateAsync(
                new EntityDto { Id = guid, Name = "Наименование" }, _ct))
            .ReturnsAsync(new Entity(){ Id = guid, Name = "Name1" });

        var controller = new UpdateEntityHandler(_repositoryMock.Object);

        // Act
        var dtoUpdated = await controller.Handle(dto, _ct);

        // Assert
        _repositoryMock.Verify(r => r.UpdateAsync(dto, _ct));
        Assert.Equal(dto, dtoUpdated);
    }
    
    [Fact]
    public async Task DeleteEntity()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var dto = new EntityDto { Id = guid, Name = "Наименование" };

        _repositoryMock.Setup(r => r.UpdateAsync(
                new EntityDto { Id = guid, Name = "Наименование" }, _ct))
            .ReturnsAsync(new Entity{ Id = guid, Name = "Name1" });

        var controller = new DeleteEntityHandler(_repositoryMock.Object);

        // Act
        var deletedGuid = await controller.Handle(dto, _ct);

        // Assert
        _repositoryMock.Verify(r => r.DeleteAsync(dto, _ct));
        Assert.Equal(guid, deletedGuid);
    }
}