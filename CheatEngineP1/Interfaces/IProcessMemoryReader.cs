using CheatEngineP1.Entities;

namespace CheatEngineP1.Interfaces;

internal interface IProcessMemoryReader
{
    Task ReadPointerValueInLoop(ProcessMemoryPointerPath processMemoryPointerPath, CancellationToken ct);
    IntPtr ReadPointerValue(ProcessMemoryPointerPath processMemoryPointerPath);
    Task ReadAddressValueInLoop(ProcessMemoryAddress processMemory, CancellationToken ct);
    IntPtr ReadAddressValue(ProcessMemoryAddress processMemoryAddress);
}