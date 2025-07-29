using CheatEngineP1.Entities;

namespace CheatEngineP1.Interfaces;

public interface IProcessPointerAddressReader
{
    Task ReadPointerAddressValueInLoop(PointerPath pointerPath, CancellationToken ct);
    IntPtr ReadPointerAddressValue(PointerPath pointerPath);
}