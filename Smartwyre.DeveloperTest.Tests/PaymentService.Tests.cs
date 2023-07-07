using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    [Fact]
    public async void SuccessTest()
    {
        var rebateService = new RebateService();
        var calculateRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "test",
            RebateIdentifier = "test",
            Volume = 1
        };

        var test = await rebateService.Calculate(calculateRequest);
    }

    [Fact]
    public async void RebateIdentifierDoesNotExistTest()
    {
        var rebateService = new RebateService();
        var calculateRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "test",
            RebateIdentifier = "DoesNotExist",
            Volume = 1
        };

        var test = await rebateService.Calculate(calculateRequest);
        Assert.False(test.Success);
    }

    [Fact]
    public async void ProductIdentifierDoesNotExistTest()
    {
        var rebateService = new RebateService();
        var calculateRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "DoesNotExist",
            RebateIdentifier = "test",
            Volume = 1
        };

        var test = await rebateService.Calculate(calculateRequest);
        Assert.False(test.Success);
    }

    [Fact]
    public async void ProductNotSupportedTest()
    {
        var rebateService = new RebateService();
        var calculateRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "test",
            RebateIdentifier = "test2",
            Volume = 1
        };

        var test = await rebateService.Calculate(calculateRequest);
        Assert.False(test.Success);
    }

    [Fact]
    public async void AmountZeroTest()
    {
        var rebateService = new RebateService();
        var calculateRequest = new CalculateRebateRequest()
        {
            ProductIdentifier = "test2",
            RebateIdentifier = "test3",
            Volume = 1
        };

        var test = await rebateService.Calculate(calculateRequest);
        Assert.False(test.Success);
    }
}
