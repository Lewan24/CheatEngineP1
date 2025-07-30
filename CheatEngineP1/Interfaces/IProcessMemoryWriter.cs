using CheatEngineP1.Entities;

namespace CheatEngineP1.Interfaces;

public interface IProcessMemoryWriter
{
    void WriteAddressValue<T>(ProcessMemoryAddress memory, T value) where T : unmanaged;
    void WritePointerValue<T>(ProcessMemoryPointerPath path, T value) where T : unmanaged;
}