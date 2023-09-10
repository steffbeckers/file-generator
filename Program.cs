using PuppeteerSharp;
using System.CommandLine;

Command rootCommand = new RootCommand("File generator");

Option<string> fileNameOption = new Option<string>("--name", "File name");
rootCommand.AddGlobalOption(fileNameOption);

rootCommand.SetHandler((context) =>
{
	Console.WriteLine("Hello World!");
});

Command pdfCommand = new Command("pdf", "Generate PDF file");

Option<string> fromHtmlOption = new Option<string>("--from-html", "Generate PDF from HTML");
pdfCommand.AddOption(fromHtmlOption);

pdfCommand.SetHandler(async (context) =>
{
	string? fileName = context.ParseResult.GetValueForOption(fileNameOption);
	string? fromHtml = context.ParseResult.GetValueForOption(fromHtmlOption);

	Console.WriteLine($"Generating PDF file with name {fileName} from HTML {fromHtml}");

	using BrowserFetcher browserFetcher = new BrowserFetcher();
	await browserFetcher.DownloadAsync();

	using IBrowser browser = await Puppeteer.LaunchAsync(new LaunchOptions()
	{
		Headless = true
	});

	using IPage page = await browser.NewPageAsync();
	await page.SetContentAsync(fromHtml);

	await page.PdfAsync(fileName);
});

rootCommand.AddCommand(pdfCommand);

await rootCommand.InvokeAsync(args);
