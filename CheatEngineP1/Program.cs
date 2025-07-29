using CheatEngineP1.Entities;
using CheatEngineP1.Interfaces;
using CheatEngineP1.Services;

ProcessCheat processCheat = new ProcessCheat("Tutorial-i386");
IProcessMemoryReader processReader = processCheat;
IProcessMemoryWriter processWriter = processCheat;

var step2HealthPointer = new ProcessMemoryPointerPath(0x240600, [0x4B4]);

var healthValue = processReader.ReadPointerValue(step2HealthPointer);
Console.WriteLine($"Health value: {healthValue}");

Console.WriteLine("Click anything to randomize health and read once more...");
Console.ReadKey();

var newHealthValue = Random.Shared.Next(100, 2000);
Console.WriteLine($"Setting health value to: {newHealthValue}");
processWriter.WritePointerValue(step2HealthPointer, newHealthValue);

healthValue = processReader.ReadPointerValue(step2HealthPointer);
Console.WriteLine($"New Health value: {healthValue}");

Console.WriteLine("\nClick anything to exit...");
Console.ReadKey();

Console.WriteLine("Thank you for using our Cheats.");