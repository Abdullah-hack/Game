using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Sounds
{
    public static class SoundManager
    {
        public static void PlayEffect(string path, float volume = 0.7f)
        {
            var output = new WaveOutEvent();
            var reader = new AudioFileReader(path) { Volume = volume };

            output.Init(reader);
            output.Play();

            output.PlaybackStopped += (s, e) =>
            {
                output.Dispose();
                reader.Dispose();
            };
        }

        private static WaveOutEvent bgOutput;
        private static AudioFileReader bgReader;

        public static void PlayMusic(string path, float volume = 0.4f)
        {
            StopMusic();

            bgOutput = new WaveOutEvent();
            bgReader = new AudioFileReader(path) { Volume = volume };

            bgOutput.Init(new LoopStream(bgReader));
            bgOutput.Play();
        }

        public static void StopMusic()
        {
            bgOutput?.Stop();
            bgOutput?.Dispose();
            bgReader?.Dispose();
        }
    }
}
