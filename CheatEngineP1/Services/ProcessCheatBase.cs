using System.Diagnostics;
using System.Runtime.InteropServices;
using CheatEngineP1.Exceptions;

namespace CheatEngineP1.Services;

internal class ProcessCheatBase(string processName)
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

    protected readonly Process? Process = Process
        .GetProcessesByName(processName)
        .FirstOrDefault();

    private IntPtr? _processHandle;
    
    protected IntPtr OpenProcess()
    {
        EnsureProcessReady();
        
        if (_processHandle is null)
            _processHandle = OpenProcess(ProcessVmRead | ProcessVmWrite | ProcessQueryInformation, false, Process!.Id);
        
        return (IntPtr)_processHandle;
    }
    private void EnsureProcessReady()
    {
        if (Process is null)
            throw new InValidProcessException();
    }
}