namespace Hiky;

public static class EventTypes
{
    public const int TamperingAlarmStarts = 0x05;
    public const int FaceAuthenticationCompleted = 0x4b;
    public const int DoorOpened = 0x15;
    public const int DoorClosed = 0x16;
    public const int DoorTimedOut = 0x1c;

    public readonly static Dictionary<int, string> EventDescriptions = new Dictionary<int, string>
    {
        { TamperingAlarmStarts, "Tampering alarm starts" },
        { DoorClosed, "Door closed" },
        { DoorTimedOut, "Door timed out" },
        { DoorOpened, "Door opened" },
        { FaceAuthenticationCompleted, "Face authentication completed" }
    };
}