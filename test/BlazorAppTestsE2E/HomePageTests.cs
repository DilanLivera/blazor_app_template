using Microsoft.Playwright;

using Xunit;

namespace BlazorAppTestsE2E;

public class HomePageTests : PlaywrightTestBase
{
    [Fact]
    public async Task HomePage_ShouldDisplayWelcomeMessage()
    {
        // Arrange
        await Page.GotoAsync(url: "http://localhost:5013");

        // Act
        string? welcomeText = await Page.TextContentAsync(selector: "h1");

        // Assert
        Assert.Contains("Welcome to Blazor App", welcomeText);
    }

    [Fact]
    public async Task HomePage_ShouldHaveSignInButton_WhenNotAuthenticated()
    {
        // Arrange
        await Page.GotoAsync(url: "http://localhost:5013");

        // Act
        IElementHandle? signInButton = await Page.QuerySelectorAsync(selector: "text=Sign In with Google");

        // Assert
        Assert.NotNull(signInButton);
    }
}