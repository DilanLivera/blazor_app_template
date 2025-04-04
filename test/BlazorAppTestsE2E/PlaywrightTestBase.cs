using Microsoft.Playwright;

using Xunit;

namespace BlazorAppTestsE2E;

public class PlaywrightTestBase : IAsyncLifetime
{
    private IPlaywright Playwright { get; set; } = null!;
    private IBrowser Browser { get; set; } = null!;
    protected IPage Page { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        BrowserTypeLaunchOptions browserTypeLaunchOptions = new() { Headless = true };
        Browser = await Playwright.Chromium.LaunchAsync(browserTypeLaunchOptions);
        Page = await Browser.NewPageAsync();
    }

    public async Task DisposeAsync()
    {
        await Page.CloseAsync();

        await Browser.DisposeAsync();

        Playwright.Dispose();
    }
}