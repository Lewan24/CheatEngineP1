using CheatEngineP1.Entities;

namespace CheatEngineP1.Interfaces;

public interface IProcessMemoryReader : IProcessInitializer
{
    Task ReadMemoryValueInLoop<T>(ProcessMemoryPointerPath path, CancellationToken ct) where T : unmanaged;
    T ReadMemoryValue<T>(ProcessMemoryPointerPath path, long? shift = null) where T : unmanaged;
}