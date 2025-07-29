using CheatEngineP1.Models;

namespace CheatEngineP1.Interfaces;

internal interface IProcessReader
{
    Task ReadAddressInLoop(ProcessCheatDetails processDetails, CancellationToken ct);
    string ReadAddress(ProcessCheatDetails processCheatDetails);
}