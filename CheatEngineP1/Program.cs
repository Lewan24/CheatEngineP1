using CheatEngineP1.Entities;
using CheatEngineP1.Interfaces;
using CheatEngineP1.Services;

IProcessPointerAddressReader processAddressReader = new ProcessAddressCheat("Tutorial-i386");
var pointerPath = new PointerPath(0x240600, [0x4B4]);

var cts = new CancellationTokenSource();
_ = processAddressReader.ReadPointerAddressValueInLoop(pointerPath, cts.Token);

Console.ReadKey();

cts.Cancel();

Console.WriteLine("Thank you for using our Cheats.");