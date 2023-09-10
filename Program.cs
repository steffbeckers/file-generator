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

pdfCommand.SetHandler((context) =>
{
	string? fileName = context.ParseResult.GetValueForOption(fileNameOption);
	string? fromHtml = context.ParseResult.GetValueForOption(fromHtmlOption);

	Console.WriteLine($"Generating PDF file with name {fileName} from HTML {fromHtml}");
});

rootCommand.AddCommand(pdfCommand);

await rootCommand.InvokeAsync(args);
