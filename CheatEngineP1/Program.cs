using CheatEngineP1.Interfaces;
using CheatEngineP1.Models;
using CheatEngineP1.Services;

IProcessReader processReader = new ProcessCheat("Tutorial-i386");
var processDetails = new ProcessCheatDetails(0x016C33F4);

var cts = new CancellationTokenSource();

_ = processReader.ReadAddressInLoop(processDetails, cts.Token);

Console.WriteLine("Press any key to stop and exit");
Console.ReadKey();

cts.Cancel();

Console.WriteLine("Thank you for using our Cheats.");