using System.Diagnostics;
using System.Runtime.InteropServices;
using CheatEngineP1.Exceptions;
using CheatEngineP1.Interfaces;

namespace CheatEngineP1.Services;

internal class ProcessCheatBase  : IDisposable, IProcessInitializer
{
    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    protected static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int size, out int lpNumberOfBytesRead);
    
    [DllImport("kernel32.dll")]
    protected static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int size, out int lpNumberOfBytesWritten);
    
    private const int ProcessVmRead = 0x0010;
    private const int ProcessVmWrite = 0x0020;
    private const int ProcessQueryInformation = 0x0400;

    protected Process? Process { get; private set; }

    private IntPtr? _processHandle;

    public void Initialize(string processName)
    {
        if (Process is not null)
            if (!Process.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase))
                Process.Dispose();
        
        Console.WriteLine($"Initializing Process with name: {processName}");
        
        Process = Process
            .GetProcessesByName(processName)
            .FirstOrDefault();
    }
    
    protected IntPtr OpenProcess()
    {
        EnsureProcessReady();

        if (_processHandle is null)
        {
            Console.WriteLine($"Opening process with name: {Process?.ProcessName}");
            _processHandle = OpenProcess(ProcessVmRead | ProcessVmWrite | ProcessQueryInformation, false, Process!.Id);
        }
        
        return (IntPtr)_processHandle;
    }
    private void EnsureProcessReady()
    {
        if (Process is null)
            throw new InValidProcessException();
    }

    public void Dispose()
    {
        Process?.Dispose();
    }
}