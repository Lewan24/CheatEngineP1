using CheatEngineP1.Entities;
using CheatEngineP1.Interfaces;
using System.Runtime.InteropServices;

namespace CheatEngineP1.Services;

internal sealed class ProcessCheat : ProcessCheatBase,
    IProcessMemoryReader,
    IProcessMemoryWriter
{
    public void WriteAddressValue<T>(ProcessMemoryAddress memory, T value) where T : unmanaged
    {
        WriteValue((IntPtr)memory.TargetAddress, value);
    }
    public void WritePointerValue<T>(ProcessMemoryPointerPath path, long? shift, T value) where T : unmanaged
    {
        var address = ResolvePointerAddress(path);
        
        if (shift is not null)
        {
            long shiftedAddress = address.ToInt64() - shift.Value;
            address = new IntPtr(shiftedAddress);
        }
        
        WriteValue(address, value);
    }

    public T ReadMemoryValue<T>(ProcessMemoryPointerPath path, long? shift = null) where T : unmanaged
    {
        var address = ResolvePointerAddress(path);
        
        if (shift is not null)
        {
            long shiftedAddress = address.ToInt64() - shift.Value;
            address = new IntPtr(shiftedAddress);
        }
        
        return ReadValue<T>(address);
    }
    public async Task ReadMemoryValueInLoop<T>(ProcessMemoryPointerPath path, CancellationToken ct) where T : unmanaged
    {
        var address = ResolvePointerAddress(path);
        await ReadAddressValueInLoop<T>(new ProcessMemoryAddress(address), ct);
    }
    
    private async Task ReadAddressValueInLoop<T>(ProcessMemoryAddress memory, CancellationToken ct) where T : unmanaged
    {
        while (!ct.IsCancellationRequested)
        {
            Console.Clear();

            var result = ReadAddressValue<T>(memory);
            Console.WriteLine($"[Value @ {memory.TargetAddress:X}] = {result}");

            Console.WriteLine("\nPress any key to stop and exit...");
            await Task.Delay(200, ct);
        }
    }
    private T ReadAddressValue<T>(ProcessMemoryAddress memory) where T : unmanaged
    {
        return ReadValue<T>((IntPtr)memory.TargetAddress);
    }

    private IntPtr ResolvePointerAddress(ProcessMemoryPointerPath pointerPath)
    {
        long currentAddress = Process!.MainModule!.BaseAddress.ToInt64() + pointerPath.BaseOffset;

        foreach (var offset in pointerPath.Offsets)
        {
            long ptr = ReadValue<long>((IntPtr)currentAddress);
            currentAddress = ptr + offset;
        }

        return (IntPtr)currentAddress;
    }
    private T ReadValue<T>(IntPtr address) where T : unmanaged
    {
        var handle = OpenProcess();
        int size = Marshal.SizeOf<T>();
        byte[] buffer = new byte[size];

        ReadProcessMemory(handle, address, buffer, size, out _);
        return MemoryMarshal.Cast<byte, T>(buffer)[0];
    }
    private void WriteValue<T>(IntPtr address, T value) where T : unmanaged
    {
        var handle = OpenProcess();
        int size = Marshal.SizeOf<T>();
        byte[] buffer = new byte[size];

        MemoryMarshal.Write(buffer, ref value);
        WriteProcessMemory(handle, address, buffer, size, out _);
    }
}
