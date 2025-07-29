using CheatEngineP1.Entities;
using CheatEngineP1.Interfaces;

namespace CheatEngineP1.Services;

internal sealed class ProcessCheat(string processName) : ProcessCheatBase(processName),
    IProcessMemoryReader,
    IProcessMemoryWriter
{
    public void WriteAddressValue(ProcessMemoryAddress processMemory, int newValue)
    {
        WriteInt32((IntPtr)processMemory.TargetAddress, newValue);
    }
    public void WritePointerValue(ProcessMemoryPointerPath processMemoryPointerPath, int newValue)
    {
        var address = ResolvePointerAddress(processMemoryPointerPath);
        WriteInt32(address, newValue);
    }
    
    public async Task ReadPointerValueInLoop(ProcessMemoryPointerPath processMemoryPointerPath, CancellationToken ct)
    {
        var desiredAddress = ResolvePointerAddress(processMemoryPointerPath);
        await ReadAddressValueInLoop(new ProcessMemoryAddress(desiredAddress), ct);
    }
    public IntPtr ReadPointerValue(ProcessMemoryPointerPath processMemoryPointerPath)
    {
        var desiredAddress = ResolvePointerAddress(processMemoryPointerPath);
        return ReadAddressValue(new ProcessMemoryAddress(desiredAddress));
    }
    
    public async Task ReadAddressValueInLoop(ProcessMemoryAddress processMemory, CancellationToken ct)
    {
        while (ct.IsCancellationRequested == false)
        {
            Console.Clear();

            var result = ReadAddressValue(processMemory);

            Console.WriteLine(result);
            Console.WriteLine("\nPress any key to stop and exit...");
            
            await Task.Delay(100, ct);
        }
    }
    public IntPtr ReadAddressValue(ProcessMemoryAddress processMemoryAddress) 
        => ReadInt32((IntPtr)processMemoryAddress.TargetAddress);
    
    private IntPtr ResolvePointerAddress(ProcessMemoryPointerPath processMemoryPointerPath)
    {
        var baseAddress = Process!.MainModule!.BaseAddress.ToInt64() + processMemoryPointerPath.BaseOffset;
        long currentAddress = baseAddress;

        foreach (var offset in processMemoryPointerPath.Offsets)
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
    private void WriteInt32(IntPtr address, int value)
    {
        var handle = OpenProcess();
        byte[] buffer = BitConverter.GetBytes(value);
        WriteProcessMemory(handle, address, buffer, buffer.Length, out _);
    }
}