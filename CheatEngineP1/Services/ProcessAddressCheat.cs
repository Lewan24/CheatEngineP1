using CheatEngineP1.Entities;
using CheatEngineP1.Interfaces;

namespace CheatEngineP1.Services;

internal sealed class ProcessAddressCheat(string processName) : ProcessCheatBase(processName), 
    IProcessAddressReader, 
    IProcessPointerAddressReader
{
    public async Task ReadPointerAddressValueInLoop(PointerPath pointerPath, CancellationToken ct)
    {
        var desiredAddress = ResolvePointerAddress(pointerPath);
        await ReadAddressValueInLoop(new ProcessAddressDetails(desiredAddress), ct);
    }
    public IntPtr ReadPointerAddressValue(PointerPath pointerPath)
    {
        var desiredAddress = ResolvePointerAddress(pointerPath);
        return ReadAddressValue(new ProcessAddressDetails(desiredAddress));
    }
    
    public async Task ReadAddressValueInLoop(ProcessAddressDetails processDetails, CancellationToken ct)
    {
        while (ct.IsCancellationRequested == false)
        {
            Console.Clear();

            var result = ReadAddressValue(processDetails);

            Console.WriteLine(result);
            Console.WriteLine("\nPress any key to stop and exit...");
            
            await Task.Delay(100, ct);
        }
    }
    public IntPtr ReadAddressValue(ProcessAddressDetails processAddressDetails) 
        => ReadInt32((IntPtr)processAddressDetails.TargetAddress);

    private IntPtr ResolvePointerAddress(PointerPath pointerPath)
    {
        var baseAddress = Process!.MainModule!.BaseAddress.ToInt64() + pointerPath.BaseOffset;
        long currentAddress = baseAddress;

        foreach (var offset in pointerPath.Offsets)
        {
            int nextAddress = ReadInt32((IntPtr)currentAddress);
            currentAddress = nextAddress + offset;
        }

        return (IntPtr)currentAddress;
    }
    private int ReadInt32(IntPtr address)
    {
        var handle = OpenProcess();
        byte[] buffer = new byte[4];
        ReadProcessMemory(handle, address, buffer, buffer.Length, out _);
        return BitConverter.ToInt32(buffer, 0);
    }
}