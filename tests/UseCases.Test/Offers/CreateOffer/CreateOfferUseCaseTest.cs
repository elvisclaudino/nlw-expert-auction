using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        // AAA

        // ARRANGE - Instancio o que eu preciso
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(200, 3000)).Generate();
            
        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        // ACT - Executo o que eu preciso
        var act = () => useCase.Execute(itemId, request);

        // ASSERT - Verifico se o resultado devolvido é o resultado esperado
        act.Should().NotThrow();
    }
}
