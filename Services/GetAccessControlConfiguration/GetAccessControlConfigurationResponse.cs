namespace Hiky.Services.GetAccessControlConfiguration;

using System.Text.Json.Serialization;

/// <summary>
/// Represents the root object for the access control configuration response.
/// </summary>
public class GetAccessControlConfigurationResponse
{
    /// <summary>
    /// Contains the detailed access control configuration settings.
    /// </summary>
    [JsonPropertyName("AcsCfg")]
    public AcsCfg? AcsCfg { get; set; }
}

/// <summary>
/// Defines the current access control configuration settings of the device.
/// </summary>
public class AcsCfg
{
    /// <summary>
    /// Gets or sets whether to enable downstream RS-485 communication redundancy.
    /// </summary>
    [JsonPropertyName("RS485Backup")]
    public bool? RS485Backup { get; set; }

    /// <summary>
    /// Gets or sets whether to display the captured picture.
    /// </summary>
    [JsonPropertyName("showCapPic")]
    public bool? ShowCapPic { get; set; }

    /// <summary>
    /// Gets or sets whether to display user information.
    /// </summary>
    [JsonPropertyName("showUserInfo")]
    public bool? ShowUserInfo { get; set; }

    /// <summary>
    /// Gets or sets whether to overlay user information on pictures.
    /// </summary>
    [JsonPropertyName("overlayUserInfo")]
    public bool? OverlayUserInfo { get; set; }

    /// <summary>
    /// Gets or sets whether to enable voice prompt.
    /// </summary>
    [JsonPropertyName("voicePrompt")]
    public bool? VoicePrompt { get; set; }

    /// <summary>
    /// Gets or sets whether to upload the picture from a linked capture.
    /// </summary>
    [JsonPropertyName("uploadCapPic")]
    public bool? UploadCapPic { get; set; }

    /// <summary>
    /// Gets or sets whether to save the captured picture.
    /// </summary>
    [JsonPropertyName("saveCapPic")]
    public bool? SaveCapPic { get; set; }

    /// <summary>
    /// Gets or sets whether to allow inputting a card number on the keypad.
    /// </summary>
    [JsonPropertyName("inputCardNo")]
    public bool? InputCardNo { get; set; }

    /// <summary>
    /// Gets or sets whether to enable Wi-Fi probe.
    /// </summary>
    [JsonPropertyName("enableWifiDetect")]
    public bool? EnableWifiDetect { get; set; }

    /// <summary>
    /// Gets or sets whether to enable 3G/4G.
    /// </summary>
    [JsonPropertyName("enable3G4G")]
    public bool? Enable3G4G { get; set; }

    /// <summary>
    /// Gets or sets the communication protocol type of the card reader.
    /// </summary>
    /// <remarks>
    /// Possible values include "Private" (private protocol) or "OSDP" (OSDP protocol).
    /// </remarks>
    [JsonPropertyName("protocol")]
    public string? Protocol { get; set; }

    /// <summary>
    /// Gets or sets whether to enable capturing the ID picture.
    /// </summary>
    /// <remarks>
    /// If this node does not exist, the function is not supported.
    /// </remarks>
    [JsonPropertyName("enableCaptureCertificate")]
    public bool? EnableCaptureCertificate { get; set; }

    /// <summary>
    /// Gets or sets whether to display the authenticated picture.
    /// </summary>
    [JsonPropertyName("showPicture")]
    public bool? ShowPicture { get; set; }

    /// <summary>
    /// Gets or sets whether to show a preset picture.
    /// </summary>
    [JsonPropertyName("showPresetPicture")]
    public bool? ShowPresetPicture { get; set; }

    /// <summary>
    /// Gets or sets whether to display the authenticated employee ID.
    /// </summary>
    [JsonPropertyName("showEmployeeNo")]
    public bool? ShowEmployeeNo { get; set; }

    /// <summary>
    /// Gets or sets whether to display the authenticated name.
    /// </summary>
    [JsonPropertyName("showName")]
    public bool? ShowName { get; set; }

    /// <summary>
    /// Gets or sets whether to show the phone number.
    /// </summary>
    [JsonPropertyName("showPhoneNo")]
    public bool? ShowPhoneNo { get; set; }

    /// <summary>
    /// Gets or sets whether to enable employee No. de-identification for local UI display.
    /// </summary>
    /// <remarks>
    /// This is dependent on ShowEmployeeNo being true.
    /// </remarks>
    [JsonPropertyName("desensitiseEmployeeNo")]
    public bool? DesensitiseEmployeeNo { get; set; }

    /// <summary>
    /// Gets or sets whether to enable name de-identification for local UI display.
    /// </summary>
    /// <remarks>
    /// This is dependent on ShowName being true.
    /// </remarks>
    [JsonPropertyName("desensitiseName")]
    public bool? DesensitiseName { get; set; }

    /// <summary>
    /// Gets or sets whether to de-sensitise the phone number.
    /// </summary>
    /// <remarks>
    /// This is dependent on ShowPhoneNo being true.
    /// </remarks>
    [JsonPropertyName("desensitisePhoneNo")]
    public bool? DesensitisePhoneNo { get; set; }

    /// <summary>
    /// Gets or sets whether to enable temperature measurement.
    /// </summary>
    [JsonPropertyName("thermalEnabled")]
    public bool? ThermalEnabled { get; set; }

    /// <summary>
    /// Gets or sets whether to enable temperature measurement only mode.
    /// </summary>
    [JsonPropertyName("thermalMode")]
    public bool? ThermalMode { get; set; }

    /// <summary>
    /// Gets or sets whether to enable uploading visible light pictures in temperature measurement only mode.
    /// </summary>
    [JsonPropertyName("thermalPictureEnabled")]
    public bool? ThermalPictureEnabled { get; set; }

    /// <summary>
    /// Gets or sets the IP address of the thermography device.
    /// </summary>
    [JsonPropertyName("thermalIp")]
    public string? ThermalIp { get; set; }

    /// <summary>
    /// Gets or sets the upper limit of the temperature threshold.
    /// </summary>
    [JsonPropertyName("highestThermalThreshold")]
    public float? HighestThermalThreshold { get; set; }

    /// <summary>
    /// Gets or sets the lower limit of the temperature threshold.
    /// </summary>
    [JsonPropertyName("lowestThermalThreshold")]
    public float? LowestThermalThreshold { get; set; }

    /// <summary>
    /// Gets or sets whether to open the door based on the temperature threshold.
    /// </summary>
    /// <remarks>
    /// If true, opens the door when temperature is outside the threshold; otherwise, it does not.
    /// </remarks>
    [JsonPropertyName("thermalDoorEnabled")]
    public bool? ThermalDoorEnabled { get; set; }

    /// <summary>
    /// Gets or sets whether the QR code function is enabled.
    /// </summary>
    [JsonPropertyName("QRCodeEnabled")]
    public bool? QrCodeEnabled { get; set; }

    /// <summary>
    /// Gets or sets whether to enable controlling the door by remote verification.
    /// </summary>
    [JsonPropertyName("remoteCheckDoorEnabled")]
    public bool? RemoteCheckDoorEnabled { get; set; }

    /// <summary>
    /// Gets or sets the verification channel type.
    /// </summary>
    /// <remarks>
    /// This is dependent on RemoteCheckDoorEnabled being true.
    /// </remarks>
    [JsonPropertyName("checkChannelType")]
    public string? CheckChannelType { get; set; }

    /// <summary>
    /// Gets or sets the IP address of the verification channel.
    /// </summary>
    /// <remarks>
    /// This field is valid when CheckChannelType is "PrivateSDK".
    /// </remarks>
    [JsonPropertyName("channelIp")]
    public string? ChannelIp { get; set; }

    /// <summary>
    /// Gets or sets whether the device needs checking.
    /// </summary>
    /// <remarks>
    /// This is dependent on RemoteCheckDoorEnabled being true.
    /// </remarks>
    [JsonPropertyName("needDeviceCheck")]
    public bool? NeedDeviceCheck { get; set; }

    /// <summary>
    /// Gets or sets the timeout for remote checking.
    /// </summary>
    /// <remarks>
    /// Unit is seconds, range is [1, 10]. Dependent on RemoteCheckDoorEnabled being true.
    /// </remarks>
    [JsonPropertyName("remoteCheckTimeout")]
    public int? RemoteCheckTimeout { get; set; }

    /// <summary>
    /// Gets or sets the remote check verification mode.
    /// </summary>
    /// <remarks>
    /// This is dependent on RemoteCheckDoorEnabled being true.
    /// </remarks>
    [JsonPropertyName("remoteCheckVerifyMode")]
    public int? RemoteCheckVerifyMode { get; set; }

    /// <summary>
    /// Gets or sets whether the offline device check can open the door.
    /// </summary>
    /// <remarks>
    /// This is dependent on RemoteCheckDoorEnabled being true.
    /// </remarks>
    [JsonPropertyName("offlineDevCheckOpenDoorEnabled")]
    public bool? OfflineDevCheckOpenDoorEnabled { get; set; }

    /// <summary>
    /// Gets or sets the remote check with ISAPI Listen mode.
    /// </summary>
    /// <remarks>
    /// This is dependent on CheckChannelType being "ISAPIListen".
    /// </remarks>
    [JsonPropertyName("remoteCheckWithISAPIListen")]
    public string? RemoteCheckWithISAPIListen { get; set; }

    /// <summary>
    /// Gets or sets whether to upload the authenticated picture.
    /// </summary>
    [JsonPropertyName("uploadVerificationPic")]
    public bool? UploadVerificationPic { get; set; }

    /// <summary>
    /// Gets or sets the type of verification picture to upload.
    /// </summary>
    [JsonPropertyName("uploadVerificationPicType")]
    public int? UploadVerificationPicType { get; set; }

    /// <summary>
    /// Gets or sets whether to save the authenticated picture.
    /// </summary>
    [JsonPropertyName("saveVerificationPic")]
    public bool? SaveVerificationPic { get; set; }

    /// <summary>
    /// Gets or sets whether to save the registered face picture.
    /// </summary>
    [JsonPropertyName("saveFacePic")]
    public bool? SaveFacePic { get; set; }

    /// <summary>
    /// Gets or sets the temperature unit.
    /// </summary>
    /// <remarks>
    /// Possible values: "celsius", "fahrenheit".
    /// </remarks>
    [JsonPropertyName("thermalUnit")]
    public string? ThermalUnit { get; set; }

    /// <summary>
    /// Gets or sets the maximum value of the temperature threshold in Fahrenheit.
    /// </summary>
    [JsonPropertyName("highestThermalThresholdF")]
    public float? HighestThermalThresholdF { get; set; }

    /// <summary>
    /// Gets or sets the minimum value of the temperature threshold in Fahrenheit.
    /// </summary>
    [JsonPropertyName("lowestThermalThresholdF")]
    public float? LowestThermalThresholdF { get; set; }

    /// <summary>
    /// Gets or sets whether to enable 5G.
    /// </summary>
    [JsonPropertyName("enable5G")]
    public bool? Enable5G { get; set; }

    /// <summary>
    /// Gets or sets the temperature compensation value.
    /// </summary>
    /// <remarks>
    /// The value is accurate to one decimal place. The unit depends on the ThermalUnit property.
    /// </remarks>
    [JsonPropertyName("thermalCompensation")]
    public float? ThermalCompensation { get; set; }

    /// <summary>
    /// Gets or sets whether the external card reader is enabled.
    /// </summary>
    [JsonPropertyName("externalCardReaderEnabled")]
    public bool? ExternalCardReaderEnabled { get; set; }

    /// <summary>
    /// Gets or sets the timeout for combination authentication.
    /// </summary>
    /// <remarks>
    /// Unit is seconds. Range is [1, 20].
    /// </remarks>
    [JsonPropertyName("combinationAuthenticationTimeout")]
    public int? CombinationAuthenticationTimeout { get; set; }

    /// <summary>
    /// Gets or sets whether to enforce a specific order for combination authentication.
    /// </summary>
    [JsonPropertyName("combinationAuthenticationLimitOrder")]
    public bool? CombinationAuthenticationLimitOrder { get; set; }

    /// <summary>
    /// Gets or sets whether password authentication is enabled.
    /// </summary>
    [JsonPropertyName("passwordEnabled")]
    public bool? PasswordEnabled { get; set; }

    /// <summary>
    /// Gets or sets whether to display gender.
    /// </summary>
    [JsonPropertyName("showGender")]
    public bool? ShowGender { get; set; }

    /// <summary>
    /// Gets or sets whether to show the sign-in time.
    /// </summary>
    [JsonPropertyName("showSignInTime")]
    public bool? ShowSignInTime { get; set; }

    /// <summary>
    /// Gets or sets whether to show custom info.
    /// </summary>
    [JsonPropertyName("showsCustomInfo")]
    public bool? ShowsCustomInfo { get; set; }

    /// <summary>
    /// Gets or sets whether to show the mobile web QR code.
    /// </summary>
    [JsonPropertyName("showMobileWebQRCode")]
    public bool? ShowMobileWebQRCode { get; set; }

    /// <summary>
    /// Gets or sets the fire alarm input type.
    /// </summary>
    [JsonPropertyName("fireAlarmInputType")]
    public string? FireAlarmInputType { get; set; }

    /// <summary>
    /// Gets or sets whether the buzzer is enabled.
    /// </summary>
    [JsonPropertyName("buzzerEnabled")]
    public bool? BuzzerEnabled { get; set; }

    /// <summary>
    /// Gets or sets whether to save visual-person audio files.
    /// </summary>
    [JsonPropertyName("saveVPAudioFile")]
    public bool? SaveVpAudioFile { get; set; }

    /// <summary>
    /// Gets or sets whether to save visual-person audio files upon authentication.
    /// </summary>
    [JsonPropertyName("saveVPAudioFileByAuth")]
    public bool? SaveVpAudioFileByAuth { get; set; }

    /// <summary>
    /// Gets or sets whether face duplicate checking is enabled.
    /// </summary>
    [JsonPropertyName("faceDuplicateCheckEnabled")]
    public bool? FaceDuplicateCheckEnabled { get; set; }

    /// <summary>
    /// Gets or sets the local controller backup mode.
    /// </summary>
    [JsonPropertyName("localControllerBackupMode")]
    public int? LocalControllerBackupMode { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of local controllers.
    /// </summary>
    [JsonPropertyName("maxlocalControllerNum")]
    public int? MaxlocalControllerNum { get; set; }

    /// <summary>
    /// Gets or sets whether to save fingerprint pictures by collection mode.
    /// </summary>
    [JsonPropertyName("saveFpPicByCollectionMode")]
    public bool? SaveFpPicByCollectionMode { get; set; }

    /// <summary>
    /// Gets or sets the face batch modeling mode.
    /// </summary>
    [JsonPropertyName("faceBatchModelingMode")]
    public string? FaceBatchModelingMode { get; set; }

    /// <summary>
    /// Gets or sets whether the display of external authentication results is enabled.
    /// </summary>
    [JsonPropertyName("externalAuthResultDisplayEnabled")]
    public bool? ExternalAuthResultDisplayEnabled { get; set; }
}

