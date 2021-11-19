using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AzNameGenerator.Converter;
using AzNameGenerator.DAL;
using AzNameGenerator.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;
using Environment = AzNameGenerator.Models.Environment;

namespace AzNameGenerator.Console
{
    public static class Program
    {
        private static IRepository<AzureRegion> _azureRegionRepository;
        private static IRepository<AzureResource> _azureResourceRepository;
        private static IRepository<Models.Environment> _environmentRepository;

        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            EnableWarpDrive(host.Services);

            StartGenerator();

            return Task.CompletedTask;
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                                       services
                                           .AddScoped<IRepository<AzureRegion>, AzureRegionRepository>()
                                           .AddScoped<IRepository<AzureResource>, AzureResourceRepository>()
                                           .AddScoped<IRepository<Models.Environment>,
                                               EnvironmentRepository>());

        private static void StartGenerator()
        {
            WriteHorizontalRule();

            var azureRegions = _azureRegionRepository.GetAll();
            var azureResources = _azureResourceRepository.GetAll();
            var environments = _environmentRepository.GetAll();

            var collection = new ConvertibleCollection();

            AskOrganization(collection);
            WriteHorizontalRule();

            AskResource(azureResources, collection);
            WriteHorizontalRule();

            AskProductName(collection);
            WriteHorizontalRule();

            AskRegion(azureRegions, collection);
            WriteHorizontalRule();

            AskEnvironment(environments, collection);
            WriteHorizontalRule();

            collection.UseLowercase();
            var lowercaseShort = GetShortFormat(collection);
            var lowercaseLong = GetLongFormat(collection);

            WriteTable(lowercaseShort, lowercaseLong);
            System.Console.ReadKey();
        }

        private static void WriteTable(string lowercaseShort, string lowercaseLong)
        {
            // Create a table
            var table = new Table();

            // Add some columns
            table.AddColumn("Short format");
            table.AddColumn("Long format");

            // Add some rows
            table.AddRow(lowercaseShort, lowercaseLong);

            table.Border = TableBorder.Rounded;

            // Render the table to the console
            AnsiConsole.Write(table);
        }

        private static void WriteHorizontalRule()
        {
            var rule = new Rule();
            AnsiConsole.Write(rule);
        }

        private static void AskOrganization(ConvertibleCollection collection)
        {
            var organization =
                RequestInput(
                    questionShortCode: "Please enter your organization short form:",
                    questionLongCode: "Please enter your organization long form:");
            collection.Add(organization);
        }

        private static void AskResource(AzureResource[] azureResources, ConvertibleCollection collection)
        {
            var selectedResource =
                RequestSelection(
                    question: "Please select a resource:",
                    azureResources);
            collection.Add(selectedResource);
        }

        private static void AskProductName(ConvertibleCollection collection)
        {
            var productName = RequestInput(
                questionShortCode: "Please enter the short format to use for the product identifier:",
                questionLongCode: "Please enter the product long format to use for the product identifier:");
            collection.Add(productName);
        }

        private static void AskRegion(AzureRegion[] azureRegions, ConvertibleCollection collection)
        {
            var selectedRegion =
                RequestSelection(
                    "Please select a region:",
                    azureRegions);

            collection.Add(selectedRegion);
        }

        private static void AskEnvironment(Environment[] environments, ConvertibleCollection collection)
        {
            var environment = RequestSelection("Please select the environment:", environments);
            collection.Add(environment);
        }

        private static string GetShortFormat(ConvertibleCollection collection)
        {
            collection.UseShortFormat();
            collection.Convert();

            var lowercaseShort = collection.GetOutput();
            return lowercaseShort;
        }

        private static string GetLongFormat(ConvertibleCollection collection)
        {
            collection.UseLongFormat();
            collection.Convert();

            var lowercaseLong = collection.GetOutput();
            return lowercaseLong;
        }

        private static void EnableWarpDrive(IServiceProvider serviceProvider)
        {
            WriteBanner();

            // Synchronous
            AnsiConsole.Status()
                .Start("Initializing warp drive...", ctx =>
                {
                    InitializeServices(serviceProvider);

                    WriteLogMessage(ctx);

                    System.Console.ReadKey();
                });

            WriteTable("[green]mcrs[/][grey]-stapp-devtest-euw-001.azurewebsites.net/[/]",
                       "[green]microsoft[/][grey]-stapp-devtest-euw-001.azurewebsites.net/[/]");
        }

        private static void WriteLogMessage(StatusContext ctx)
        {
            AnsiConsole.MarkupLine("[grey]LOG:[/] Starting gravimetric field displacement manifold...");
            Thread.Sleep(500);

            AnsiConsole.MarkupLine("[grey]LOG:[/] Warming up deuterium chamber...");
            Thread.Sleep(500);

            AnsiConsole.MarkupLine("[grey]LOG:[/] Generating antideuterium...");
            Thread.Sleep(500);

            AnsiConsole.MarkupLine("[grey]LOG:[/] Unfolding left warp nacelle...");

            ctx.Status("Unfolding warp nacelles...");
            ctx.Spinner(Spinner.Known.Dots5);
            Thread.Sleep(500);

            AnsiConsole.MarkupLine("[grey]LOG:[/] Left warp nacelle [green]online[/]...");
            AnsiConsole.MarkupLine("[grey]LOG:[/] Unfolding right warp nacelle...");
            Thread.Sleep(500);

            AnsiConsole.MarkupLine("[grey]LOG:[/] Right warp nacelle [green]online[/]...");
            ctx.Status("Generating warp bubble");
            Thread.Sleep(500);

            AnsiConsole.MarkupLine("[grey]LOG:[/] Enabling interior dampening..");
            ctx.Spinner(Spinner.Known.Clock);
            ctx.Status("Performing safety checks...");

            Thread.Sleep(500);
            AnsiConsole.MarkupLine("[grey]LOG:[/] Interior dampening [green]activated[/]...");
            AnsiConsole.MarkupLine("[grey]LOG:[/] Preparing for warp...");
            Thread.Sleep(500);

            ctx.Spinner(Spinner.Known.Star);
            for (var phase = 0M; phase <= 9.8M; phase += 1.4M)
            {
                Thread.Sleep(150);
                ctx.Status($"Warp {phase}...");
            }

            ctx.Spinner(Spinner.Known.Grenade);
            ctx.SpinnerStyle(Style.Parse("green"));
            ctx.Status("Cruising at warp 9.8...");
            Thread.Sleep(1000);
            ctx.Status("Press any key to start");
        }

        private static void WriteBanner()
        {
            AnsiConsole.Write(
                new FigletText("Welcome to the")
                    .LeftAligned()
                    .Color(Color.Red));

            AnsiConsole.Write(
                new FigletText("Azure Naming Convention")
                    .Centered()
                    .Color(Color.Green));

            AnsiConsole.Write(
                new FigletText("tool")
                    .RightAligned()
                    .Color(Color.Blue));
        }

        private static void InitializeServices(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var provider = serviceScope.ServiceProvider;

            _azureRegionRepository = provider.GetRequiredService<IRepository<AzureRegion>>();
            _azureResourceRepository = provider.GetRequiredService<IRepository<AzureResource>>();
            _environmentRepository = provider.GetRequiredService<IRepository<Models.Environment>>();
        }

        private static IEntity RequestSelection(string question, IEnumerable<IEntity> collection)
        {
            var collectionArray = collection as IEntity[] ?? collection.ToArray();
            var prompt = new SelectionPrompt<string>()
                .Title(question)
                .PageSize(30)
                .MoreChoicesText("[grey]Move up and down to reveal more[/]");
            var groups = collectionArray.GroupBy(entity => entity.GetScope());

            foreach (var grouping in groups)
            {
                prompt.AddChoiceGroup(grouping.Key, grouping.Select(entity => entity.GetName()));
            }

            var selected = AnsiConsole.Prompt(prompt);
            AnsiConsole.WriteLine($"Please select a resource: {selected}");
            return collectionArray.First(entity => string.Equals(entity.GetName(), selected));
        }

        private static IEntity RequestInput(string questionShortCode, string questionLongCode)
        {
            var genericEntity = new GenericEntity();

            genericEntity.SetShortCode(AnsiConsole.Ask<string>(questionShortCode));
            genericEntity.SetLongCode(AnsiConsole.Ask<string>(questionLongCode));

            return genericEntity;
        }
    }
}
