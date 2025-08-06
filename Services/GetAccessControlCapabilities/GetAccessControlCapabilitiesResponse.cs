using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hiky.Services.GetAccessControlCapabilities;

/// <summary>
/// Represents the root object for the access control capabilities response.
/// </summary>
public class GetAccessControlCapabilitiesResponse
{
    /// <summary>
    /// Contains the detailed access control configuration capabilities.
    /// </summary>
    [JsonPropertyName("AcsCfg")]
    public AcsCfg? AcsCfg { get; set; }
}

/// <summary>
/// Defines the access control configuration capabilities of the device.
/// </summary>
public class AcsCfg
{
    /// <summary>
    /// Gets or sets whether to enable voice prompt.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("voicePrompt")]
    public string? VoicePrompt { get; set; }

    /// <summary>
    /// Gets or sets whether to upload the picture from a linked capture.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("uploadCapPic")]
    public string? UploadCapPic { get; set; }

    /// <summary>
    /// Gets or sets whether to save the captured picture.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("saveCapPic")]
    public string? SaveCapPic { get; set; }

    /// <summary>
    /// Gets or sets the communication protocol type capabilities of the card reader.
    /// </summary>
    [JsonPropertyName("protocol")]
    public ProtocolCapability? Protocol { get; set; }

    /// <summary>
    /// Gets or sets whether to display the authenticated picture.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("showPicture")]
    public string? ShowPicture { get; set; }

    /// <summary>
    /// Gets or sets whether to display the authenticated employee ID.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("showEmployeeNo")]
    public string? ShowEmployeeNo { get; set; }

    /// <summary>
    /// Gets or sets whether to display the authenticated name.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("showName")]
    public string? ShowName { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable employee No. de-identification for local UI display.
    /// </summary>
    [JsonPropertyName("desensitiseEmployeeNo")]
    public BooleanCapability? DesensitiseEmployeeNo { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable name de-identification for local UI display.
    /// </summary>
    [JsonPropertyName("desensitiseName")]
    public BooleanCapability? DesensitiseName { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable temperature measurement.
    /// </summary>
    [JsonPropertyName("thermalEnabled")]
    public BooleanCapability? ThermalEnabled { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable temperature measurement only mode.
    /// </summary>
    /// <remarks>
    /// If true, the device is for temperature measurement only. Default is false.
    /// </remarks>
    [JsonPropertyName("thermalMode")]
    public BooleanCapability? ThermalMode { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable uploading visible light pictures in temperature measurement only mode.
    /// </summary>
    [JsonPropertyName("thermalPictureEnabled")]
    public BooleanCapability? ThermalPictureEnabled { get; set; }

    /// <summary>
    /// Gets or sets the maximum value of the temperature threshold in Celsius.
    /// </summary>
    /// <remarks>
    /// The value is accurate to one decimal place. Unit: Celsius.
    /// </remarks>
    [JsonPropertyName("highestThermalThreshold")]
    public FloatRangeCapability? HighestThermalThreshold { get; set; }

    /// <summary>
    /// Gets or sets the minimum value of the temperature threshold in Celsius.
    /// </summary>
    /// <remarks>
    /// The value is accurate to one decimal place. Unit: Celsius.
    /// </remarks>
    [JsonPropertyName("lowestThermalThreshold")]
    public FloatRangeCapability? LowestThermalThreshold { get; set; }

    /// <summary>
    /// Gets or sets whether to open the door according to the temperature threshold.
    /// </summary>
    /// <remarks>
    /// If true, the door opens even if temperature is outside the threshold. Default is false.
    /// </remarks>
    [JsonPropertyName("thermalDoorEnabled")]
    public BooleanCapability? ThermalDoorEnabled { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable QR code function.
    /// </summary>
    [JsonPropertyName("QRCodeEnabled")]
    public BooleanCapability? QrCodeEnabled { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable controlling the door by remote verification.
    /// </summary>
    [JsonPropertyName("remoteCheckDoorEnabled")]
    public BooleanCapability? RemoteCheckDoorEnabled { get; set; }

    /// <summary>
    /// Gets or sets the available verification channel types.
    /// </summary>
    [JsonPropertyName("checkChannelType")]
    public StringListCapability? CheckChannelType { get; set; }

    /// <summary>
    /// Gets or sets whether the device supports configuring the IP address of the verification channel.
    /// </summary>
    [JsonPropertyName("isSupportChannelIp")]
    public bool? IsSupportChannelIp { get; set; }

    /// <summary>
    /// Gets or sets whether to upload the authenticated picture.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("uploadVerificationPic")]
    public string? UploadVerificationPic { get; set; }

    /// <summary>
    /// Gets or sets whether to save the authenticated picture.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("saveVerificationPic")]
    public string? SaveVerificationPic { get; set; }

    /// <summary>
    /// Gets or sets whether to save the registered face picture.
    /// </summary>
    /// <remarks>
    /// Expected values: "true" or "false".
    /// </remarks>
    [JsonPropertyName("saveFacePic")]
    public string? SaveFacePic { get; set; }

    /// <summary>
    /// Gets or sets the available temperature units.
    /// </summary>
    [JsonPropertyName("thermalUnit")]
    public StringListCapability? ThermalUnit { get; set; }

    /// <summary>
    /// Gets or sets the maximum value of the temperature threshold in Fahrenheit.
    /// </summary>
    /// <remarks>
    /// The value is accurate to one decimal place. Unit: Fahrenheit.
    /// </remarks>
    [JsonPropertyName("highestThermalThresholdF")]
    public FloatRangeCapability? HighestThermalThresholdF { get; set; }

    /// <summary>
    /// Gets or sets the minimum value of the temperature threshold in Fahrenheit.
    /// </summary>
    /// <remarks>
    /// The value is accurate to one decimal place. Unit: Fahrenheit.
    /// </remarks>
    [JsonPropertyName("lowestThermalThresholdF")]
    public FloatRangeCapability? LowestThermalThresholdF { get; set; }

    /// <summary>
    /// Gets or sets the temperature compensation range.
    /// </summary>
    [JsonPropertyName("thermalCompensation")]
    public FloatRangeCapability? ThermalCompensation { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable an external card reader.
    /// </summary>
    [JsonPropertyName("externalCardReaderEnabled")]
    public BooleanCapability? ExternalCardReaderEnabled { get; set; }

    /// <summary>
    /// Gets or sets the range for the combination authentication timeout.
    /// </summary>
    /// <remarks>
    /// Unit is seconds. Range: [1, 20].
    /// </remarks>
    [JsonPropertyName("combinationAuthenticationTimeout")]
    public IntRangeCapability? CombinationAuthenticationTimeout { get; set; }

    /// <summary>
    /// Gets or sets the capability to enforce a specific order in combination authentication.
    /// </summary>
    [JsonPropertyName("combinationAuthenticationLimitOrder")]
    public BooleanCapability? CombinationAuthenticationLimitOrder { get; set; }

    /// <summary>
    /// Gets or sets the capability to enable the buzzer.
    /// </summary>
    [JsonPropertyName("buzzerEnabled")]
    public BooleanCapability? BuzzerEnabled { get; set; }

    /// <summary>
    /// Gets or sets the capability to save visual-person audio files.
    /// </summary>
    [JsonPropertyName("saveVPAudioFile")]
    public BooleanCapability? SaveVpAudioFile { get; set; }

    /// <summary>
    /// Gets or sets the capability to save visual-person audio files upon authentication.
    /// </summary>
    [JsonPropertyName("saveVPAudioFileByAuth")]
    public BooleanCapability? SaveVpAudioFileByAuth { get; set; }
}

#region Helper Classes

/// <summary>
/// Represents a capability with a list of boolean options.
/// </summary>
public class BooleanCapability
{
    /// <summary>
    /// The list of available boolean options.
    /// </summary>
    [JsonPropertyName("@opt")]
    public List<bool>? Options { get; set; }
}

/// <summary>
/// Represents a capability with a list of string options.
/// </summary>
public class StringListCapability
{
    /// <summary>
    /// The list of available string options.
    /// </summary>
    [JsonPropertyName("@opt")]
    public List<string>? Options { get; set; }
}

/// <summary>
/// Represents a capability with a settable floating-point range.
/// </summary>
public class FloatRangeCapability
{
    /// <summary>
    /// The minimum value.
    /// </summary>
    [JsonPropertyName("@min")]
    public float Min { get; set; }

    /// <summary>
    /// The maximum value.
    /// </summary>
    [JsonPropertyName("@max")]
    public float Max { get; set; }
}

/// <summary>
/// Represents a capability with a settable integer range.
/// </summary>
public class IntRangeCapability
{
    /// <summary>
    /// The minimum value.
    /// </summary>
    [JsonPropertyName("@min")]
    public int Min { get; set; }

    /// <summary>
    /// The maximum value.
    /// </summary>
    [JsonPropertyName("@max")]
    public int Max { get; set; }
}

/// <summary>
/// Represents the communication protocol capability.
/// </summary>
public class ProtocolCapability
{
    /// <summary>
    /// The available protocol options as a comma-separated string.
    /// </summary>
    /// <remarks>
    /// Example values: "Private,OSDP".
    /// </remarks>
    [JsonPropertyName("@opt")]
    public string? Options { get; set; }
}

#endregion

