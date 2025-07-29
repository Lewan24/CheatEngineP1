using CheatEngineP1.Entities;

namespace CheatEngineP1.Interfaces;

internal interface IProcessAddressReader
{
    
    Task ReadAddressValueInLoop(ProcessAddressDetails processDetails, CancellationToken ct);
    IntPtr ReadAddressValue(ProcessAddressDetails processAddressDetails);
}