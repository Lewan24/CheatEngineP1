using CheatEngineP1.Interfaces;
using CheatEngineP1.Models;

namespace CheatEngineP1.Services;

internal sealed class ProcessCheat(string processName) : ProcessCheatBase(processName), IProcessReader
{
    public async Task ReadAddressInLoop(ProcessCheatDetails processDetails, CancellationToken ct)
    {
        while (ct.IsCancellationRequested == false)
        {
            Console.Clear();

            var result = ReadAddress(processDetails);

            Console.WriteLine(result);
            await Task.Delay(100, ct);
        }
    }
    public string ReadAddress(ProcessCheatDetails processCheatDetails)
    {
        var handle = OpenProcess(); 

        byte[] buffer = new byte[4];
        ReadProcessMemory(handle, (IntPtr)processCheatDetails.TargetAddress, buffer, buffer.Length, out _);
        
        int value = BitConverter.ToInt32(buffer, 0);
        
        return $"Found value: ('{value}')";
    }
}