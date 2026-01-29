using Spectre.Console;

namespace CSharpTuiTemplate;

class Program
{
    static void Main(string[] args)
    {
        // Display a colorful title
        AnsiConsole.Write(
            new FigletText("TUI Template")
                .Centered()
                .Color(Color.Cyan1));

        AnsiConsole.MarkupLine("[grey]Powered by Spectre.Console with Native AOT[/]\n");

        // Show a table
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]Feature[/]");
        table.AddColumn("[green]Status[/]");
        table.AddRow("Spectre.Console", "[green]✓ Enabled[/]");
        table.AddRow("Native AOT", "[green]✓ Enabled[/]");
        table.AddRow("GitHub Actions", "[green]✓ Configured[/]");
        AnsiConsole.Write(table);

        AnsiConsole.WriteLine();

        // Interactive menu
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[cyan]What would you like to do?[/]")
                .PageSize(10)
                .AddChoices(new[] {
                    "Show progress bar",
                    "Show status updates",
                    "Exit"
                }));

        switch (choice)
        {
            case "Show progress bar":
                ShowProgressBar();
                break;
            case "Show status updates":
                ShowStatus();
                break;
            case "Exit":
                AnsiConsole.MarkupLine("[grey]Goodbye![/]");
                break;
        }
    }

    static void ShowProgressBar()
    {
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task = ctx.AddTask("[green]Processing...[/]");

                while (!ctx.IsFinished)
                {
                    task.Increment(2);
                    Thread.Sleep(50);
                }
            });

        AnsiConsole.MarkupLine("[green]✓ Done![/]");
    }

    static void ShowStatus()
    {
        AnsiConsole.Status()
            .Start("Thinking...", ctx =>
            {
                Thread.Sleep(1000);
                ctx.Status("[green]Working...[/]");
                Thread.Sleep(1000);
                ctx.Status("[green]Almost there...[/]");
                Thread.Sleep(1000);
            });

        AnsiConsole.MarkupLine("[green]✓ Complete![/]");
    }
}
