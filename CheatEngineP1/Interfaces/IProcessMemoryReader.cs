using CheatEngineP1.Entities;

namespace CheatEngineP1.Interfaces;

public interface IProcessMemoryReader
{
    Task ReadMemoryValueInLoop<T>(ProcessMemoryPointerPath path, CancellationToken ct) where T : unmanaged;
    T ReadMemoryValue<T>(ProcessMemoryPointerPath path) where T : unmanaged;
}