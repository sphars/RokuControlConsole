using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RokuControlConsole.Models
{
    [Serializable]
	[XmlRoot(ElementName = "device-info")]
    public class RokuDevice
    {
		[XmlElement(ElementName = "udn")]
        public string Udn { get; set; }

		[XmlElement(ElementName = "serial-number")]
		public string SerialNumber { get; set; }

		[XmlElement(ElementName = "device-id")]
		public string DeviceId { get; set; }

		[XmlElement(ElementName = "advertising-id")]
		public string AdvertisingId { get; set; }

		[XmlElement(ElementName = "vendor-name")]
		public string VendorName { get; set; }

		[XmlElement(ElementName = "model-name")]
		public string ModelName { get; set; }

		[XmlElement(ElementName = "model-number")]
		public string ModelNumber { get; set; }

		[XmlElement(ElementName = "model-region")]
		public string ModelRegion { get; set; }

		[XmlElement(ElementName = "is-tv")]
		public bool IsTV { get; set; }

		[XmlElement(ElementName = "is-stick")]
		public bool IsStick { get; set; }

		[XmlElement(ElementName = "screen-size")]
		public int ScreenSize { get; set; }

		[XmlElement(ElementName = "panel-id")]
		public int PanelId { get; set; }

		[XmlElement(ElementName = "ui-resolution")]
		public string UiResolution { get; set; }

		[XmlElement(ElementName = "tuner-type")]
		public string TunerType { get; set; }

		[XmlElement(ElementName = "supports-ethernet")]
		public bool SupportsEthernet { get; set; }

		[XmlElement(ElementName = "wifi-mac")]
		public string WifiMac { get; set; }

		[XmlElement(ElementName = "wifi-driver")]
		public string WifiDriver { get; set; }

		[XmlElement(ElementName = "has-wifi-extender")]
		public bool HasWifiExtender { get; set; }

		[XmlElement(ElementName = "has-wifi-5G-support")]
		public bool HasWifi5GSupport { get; set; }

		[XmlElement(ElementName = "can-use-wifi-extender")]
		public bool CanUsewifiExtender { get; set; }

		[XmlElement(ElementName = "ethernet-mac")]
		public string EthernetMac { get; set; }

		[XmlElement(ElementName = "network-type")]
		public string NetworkType { get; set; }

		[XmlElement(ElementName = "network-name")]
		public string NetworkName { get; set; }

		[XmlElement(ElementName = "friendly-device-name")]
		public string FriendlyDeviceName { get; set; }

		[XmlElement(ElementName = "friendly-model-name")]
		public string FriendlyModelName { get; set; }

		[XmlElement(ElementName = "default-device-name")]
		public string DefaultDeviceName { get; set; }

		[XmlElement(ElementName = "user-device-name")]
		public string UserDeviceName { get; set; }

		[XmlElement(ElementName = "user-device-location")]
		public string UserDeviceLocation { get; set; }

		[XmlElement(ElementName = "build-number")]
		public string BuildNumber { get; set; }

		[XmlElement(ElementName = "software-version")]
		public string SoftwareVersion { get; set; }

		[XmlElement(ElementName = "software-build")]
		public string SoftwareBuild { get; set; }

		[XmlElement(ElementName = "secure-device")]
		public bool SecureDevice { get; set; }

		[XmlElement(ElementName = "language")]
		public string Language { get; set; }

		[XmlElement(ElementName = "country")]
		public string Country { get; set; }

		[XmlElement(ElementName = "locale")]
		public string Locale { get; set; }

		[XmlElement(ElementName = "time-zone-auto")]
		public bool TimeZoneAuto { get; set; }

		[XmlElement(ElementName = "time-zone")]
		public string TimeZone { get; set; }

		[XmlElement(ElementName = "time-zone-name")]
		public string TimeZoneName { get; set; }

		[XmlElement(ElementName = "time-zone-tz")]
		public string TimeZoneTz { get; set; }

		[XmlElement(ElementName = "time-zone-offset")]
		public string TimeZoneOffset { get; set; }

		[XmlElement(ElementName = "clock-format")]
		public string ClockFormat { get; set; }

		[XmlElement(ElementName = "uptime")]
		public int Uptime { get; set; }

		[XmlElement(ElementName = "power-mode")]
		public string PowerMode { get; set; }

		[XmlElement(ElementName = "supports-suspend")]
		public bool SupportsSuspend { get; set; }

		[XmlElement(ElementName = "supports-find-remote")]
		public bool SupportsFindRemote { get; set; }

		[XmlElement(ElementName = "find-remote-is-possible")]
		public bool FindRemoteIsPossible { get; set; }

		[XmlElement(ElementName = "supports-audio-guide")]
		public bool SupportsAudioGuide { get; set; }

		[XmlElement(ElementName = "supports-rva")]
		public bool SupportsRva { get; set; }

		[XmlElement(ElementName = "developer-enabled")]
		public bool DeveloperEnabled { get; set; }

		[XmlElement(ElementName = "keyed-developer-id")]
		public object KeyedDeveloperId { get; set; }

		[XmlElement(ElementName = "search-enabled")]
		public bool SearchEnabled { get; set; }

		[XmlElement(ElementName = "search-channels-enabled")]
		public bool SearchChannelsEnabled { get; set; }

		[XmlElement(ElementName = "voice-search-enabled")]
		public bool VoiceSearchEnabled { get; set; }

		[XmlElement(ElementName = "notifications-enabled")]
		public bool NotificationsEnabled { get; set; }

		[XmlElement(ElementName = "notifications-first-use")]
		public bool NotificationsFirstUse { get; set; }

		[XmlElement(ElementName = "supports-private-listening")]
		public bool SupportsPrivateListening { get; set; }

		[XmlElement(ElementName = "supports-private-listening-dtv")]
		public bool SupportsPrivateListeningDtv { get; set; }

		[XmlElement(ElementName = "supports-warm-standby")]
		public bool SupportsWarmStandby { get; set; }

		[XmlElement(ElementName = "headphones-connected")]
		public bool HeadphonesConnected { get; set; }

		[XmlElement(ElementName = "supports-audio-settings")]
		public bool SupportsAudioSettings { get; set; }

		[XmlElement(ElementName = "expert-pq-enabled")]
		public string ExpertPqEnabled { get; set; }

		[XmlElement(ElementName = "supports-ecs-textedit")]
		public bool SupportsEcsTextedit { get; set; }

		[XmlElement(ElementName = "supports-ecs-microphone")]
		public bool SupportsEcsMicrophone { get; set; }

		[XmlElement(ElementName = "supports-wake-on-wlan")]
		public bool SupportsWakeOnWlan { get; set; }

		[XmlElement(ElementName = "supports-airplay")]
		public bool SupportsAirplay { get; set; }

		[XmlElement(ElementName = "has-play-on-roku")]
		public bool HasPlayOnRoku { get; set; }

		[XmlElement(ElementName = "has-mobile-screensaver")]
		public bool HasMobileScreensaver { get; set; }

		[XmlElement(ElementName = "support-url")]
		public string SupportUrl { get; set; }

		[XmlElement(ElementName = "grandcentral-version")]
		public string GrandcentralVersion { get; set; }

		[XmlElement(ElementName = "trc-version")]
		public string TrcVersion { get; set; }

		[XmlElement(ElementName = "trc-channel-version")]
		public string TrcChannelVersion { get; set; }

		[XmlElement(ElementName = "davinci-version")]
		public string DavinciVersion { get; set; }

	}
}
