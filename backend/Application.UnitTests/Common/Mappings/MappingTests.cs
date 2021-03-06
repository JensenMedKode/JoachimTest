using Application.ExampleChildren.Queries;
using Application.ExampleChildren.Queries.GetExampleChildDetails;
using AutoMapper;
using Domain.Entities;
using System;
using Xunit;

namespace Application.UnitTests.Common.Mappings
{
  public class MappingTests : IClassFixture<MappingTestsFixture>
  {
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests(MappingTestsFixture fixture)
    {
      _configuration = fixture.ConfigurationProvider;
      _mapper = fixture.Mapper;
    }

    [Fact]
    public void ShouldHaveValidConfiguration()
    {
      _configuration.AssertConfigurationIsValid();
    }

    [Theory]
    [InlineData(typeof(ExampleChild), typeof(ExampleChildDetailsQueryDto))]
    [InlineData(typeof(ExampleChild), typeof(BaseExampleChildQueryDto))]
    [InlineData(typeof(ExampleParent), typeof(ExampleChildParentDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
      var instance = Activator.CreateInstance(source);

      _mapper.Map(instance, source, destination);
    }

  }
}
