namespace PersistentAnalysis;

using System.Text.Json;
using Microsoft.Win32;
using ProcessCommunication;

public static partial class Persist
{
    private static string? GetWindowsDeviceId()
    {
        try
        {
            string? DeviceId = null;

            using RegistryKey LocalKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using RegistryKey? SqmClientKey = LocalKey.OpenSubKey(@"SOFTWARE\Microsoft\SQMClient");
            DeviceId = SqmClientKey?.GetValue("MachineId")?.ToString()?.Trim();
            return DeviceId;
        }
        catch
        {
            return null;
        }
    }

    private static bool Send(Command command)
    {
        if (Channel is not null && Channel.IsOpen)
        {
            string Text = JsonSerializer.Serialize(command);
            byte[] Data = Converter.EncodeString(Text);
            if (Channel.GetFreeLength() >= Data.Length)
            {
                Channel.Write(Data);
                return true;
            }
        }

        return false;
    }

    private static void Trace(string message)
    {
        Logger.Log(message);
    }
}
