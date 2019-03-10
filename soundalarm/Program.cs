using System;
using System.Media;
using CSCore.CoreAudioAPI;

namespace AudioDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            while(!IsAudioPlaying(GetDefaultRenderDevice()))
            {

            }

            PlayAlarm();
            Console.ReadLine();
        }

        public static MMDevice GetDefaultRenderDevice()
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            }
        }

        public static bool IsAudioPlaying(MMDevice device)
        {
            using (var meter = AudioMeterInformation.FromDevice(device))
            {
                return meter.PeakValue > 0;
            }
        }

        private static void PlayAlarm()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\voodoo-child.wav";
            player.PlayLooping();
        }
    }
}