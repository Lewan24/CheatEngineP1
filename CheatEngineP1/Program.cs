using CheatEngineP1.Entities;
using CheatEngineP1.Services;

// Sample Game to test Cheat Service
var processCheat = new ProcessCheat("Palworld-Win64-Shipping");
var spheresCountAddress = new ProcessMemoryPointerPath(0x08C29800, [0x178, 0x200, 0xB0, 0x30, 0x70, 0x118, 0x154]);

var spheresCount = processCheat.ReadMemoryValue<int>(spheresCountAddress);
Console.WriteLine($"Starting Spheres value: {spheresCount}");

processCheat.WritePointerValue(spheresCountAddress, 600);

spheresCount = processCheat.ReadMemoryValue<int>(spheresCountAddress);
Console.WriteLine($"Final Spheres value: {spheresCount}");

Console.WriteLine("\nClick anything to exit...");
Console.ReadKey();

Console.WriteLine("Thank you for using our Cheats.");