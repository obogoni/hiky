using System;
using System.Text.Json.Serialization;

namespace Hiky;

public class AccessControllerEvent
{
    [JsonPropertyName("ipAddress")]
    public string IpAddress { get; set; }

    [JsonPropertyName("portNo")]
    public int PortNo { get; set; }

    [JsonPropertyName("protocol")]
    public string Protocol { get; set; }

    [JsonPropertyName("macAddress")]
    public string MacAddress { get; set; }

    [JsonPropertyName("channelID")]
    public int ChannelId { get; set; }

    [JsonPropertyName("dateTime")]
    public DateTimeOffset DateTime { get; set; }

    [JsonPropertyName("activePostCount")]
    public int ActivePostCount { get; set; }

    [JsonPropertyName("eventType")]
    public string EventType { get; set; }

    [JsonPropertyName("eventState")]
    public string EventState { get; set; }

    [JsonPropertyName("eventDescription")]
    public string EventDescription { get; set; }

    [JsonPropertyName("AccessControllerEvent")]
    public AccessControllerEventDetail? Details { get; set; }
}

public class AccessControllerEventDetail
{
    [JsonPropertyName("deviceName")]
    public string DeviceName { get; set; }

    [JsonPropertyName("majorEventType")]
    public int MajorEventType { get; set; }

    [JsonPropertyName("subEventType")]
    public int SubEventType { get; set; }

    [JsonPropertyName("cardNo")]
    public string CardNo { get; set; }

    [JsonPropertyName("cardType")]
    public int CardType { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("cardReaderKind")]
    public int CardReaderKind { get; set; }

    [JsonPropertyName("cardReaderNo")]
    public int CardReaderNo { get; set; }

    [JsonPropertyName("verifyNo")]
    public int VerifyNo { get; set; }

    [JsonPropertyName("employeeNoString")]
    public string? EmployeeNoString { get; set; }

    [JsonPropertyName("serialNo")]
    public int SerialNo { get; set; }

    [JsonPropertyName("remoteCheck")]
    public bool RemoteCheck { get; set; }

    [JsonPropertyName("userType")]
    public string? UserType { get; set; }

    [JsonPropertyName("currentVerifyMode")]
    public string? CurrentVerifyMode { get; set; }

    [JsonPropertyName("attendanceStatus")]
    public string? AttendanceStatus { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("statusValue")]
    public int StatusValue { get; set; }

    [JsonPropertyName("mask")]
    public string? Mask { get; set; }

    [JsonPropertyName("purePwdVerifyEnable")]
    public bool PurePwdVerifyEnable { get; set; }

    [JsonPropertyName("unlockRoomNo")]
    public string? UnlockRoomNo { get; set; }
}
