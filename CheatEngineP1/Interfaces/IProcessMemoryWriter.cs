using CheatEngineP1.Entities;

namespace CheatEngineP1.Interfaces;

public interface IProcessMemoryWriter
{
    void WriteAddressValue(ProcessMemoryAddress processMemory, int newValue);
    void WritePointerValue(ProcessMemoryPointerPath processMemoryPointerPath, int newValue);
}