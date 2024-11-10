namespace PersistentAnalysis;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Contracts;
using Microsoft.Win32;
using ProcessCommunication;

/// <summary>
/// Provides tools for analyzers that need persistence.
/// </summary>
public static partial class Persist
{
    private static string? GetWindowsDeviceId()
    {
        using RegistryKey LocalKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
        using RegistryKey? SqmClientKey = LocalKey.OpenSubKey(@"SOFTWARE\Microsoft\SQMClient");
        RegistryKey Key = Contract.AssertNotNull(SqmClientKey);
        object MachineId = Contract.AssertNotNull(Key.GetValue("MachineId"));
        string MachineIdString = Contract.AssertNotNull(MachineId.ToString());
        string DeviceId = MachineIdString.Trim();

        return DeviceId;
    }

    private static bool Send(Command command)
    {
        IChannel OpenChannel = Contract.AssertNotNull(Channel);
        Contract.Assert(OpenChannel.IsOpen);

        string Text = JsonSerializer.Serialize(command, SerializingOptions);
        Console.WriteLine(Text);

        byte[] Data = Converter.EncodeString(Text);
        if (OpenChannel.GetFreeLength() >= Data.Length)
        {
            OpenChannel.Write(Data);
            return true;
        }

        return false;
    }

    private static void Trace(string message)
    {
        Logger.Log(message);
    }

    private static readonly JsonSerializerOptions SerializingOptions = new()
    {
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
        },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        PropertyNameCaseInsensitive = true,
    };

    private static readonly JsonSerializerOptions DeserializingOptions = new()
    {
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
        },
        PropertyNameCaseInsensitive = true,
    };
}
