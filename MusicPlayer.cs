using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace TemTunesPlayer
{

    class MusicPlayer
    {

        private bool playing = false;
        private long stopPlayingInternalLong = 0;

        private bool stopPlaying
        {
            get
            {
                return Interlocked.Read(ref stopPlayingInternalLong) == 1;
            }
            set
            {
                Interlocked.Exchange(ref stopPlayingInternalLong, Convert.ToInt64(value));
            }
        }

        public event EventHandler playingStarted;
        public event EventHandler playingStopped;

        private InputSimulator input = new InputSimulator();

        private readonly Dictionary<Tuple<Octave, Octave>, int> octaveChanges = new Dictionary<Tuple<Octave, Octave>, int>()
        {
            { new Tuple<Octave, Octave>(Octave.BLUE, Octave.ORANGE), 1 },
            { new Tuple<Octave, Octave>(Octave.BLUE, Octave.PINK), 2 },
            { new Tuple<Octave, Octave>(Octave.ORANGE, Octave.BLUE), -1 },
            { new Tuple<Octave, Octave>(Octave.ORANGE, Octave.PINK), 1 },
            { new Tuple<Octave, Octave>(Octave.PINK, Octave.BLUE), -2 },
            { new Tuple<Octave, Octave>(Octave.PINK, Octave.ORANGE), -1 },
        };

        private void OctaveDown()
        {
            //Press octave down
            input.Keyboard.KeyPress(VirtualKeyCode.VK_9);
            //Sleeping 20ms after a press seems necessary
            Thread.Sleep(20);
        }

        private void OctaveUp()
        {
            //Press octave up
            input.Keyboard.KeyPress(VirtualKeyCode.VK_0);
            //Sleeping 20ms after a press seems necessary
            Thread.Sleep(20);
        }

        private void StartPlayingTone(String tone)
        {
            switch (tone)
            {
                case "e1":
                    input.Keyboard.KeyDown(VirtualKeyCode.VK_1);
                    break;
                case "fis":
                    input.Keyboard.KeyDown(VirtualKeyCode.VK_2);
                    break;
                case "gis":
                    input.Keyboard.KeyDown(VirtualKeyCode.VK_3);
                    break;
                case "a":
                    input.Keyboard.KeyDown(VirtualKeyCode.VK_4);
                    break;
                case "h":
                    input.Keyboard.KeyDown(VirtualKeyCode.VK_5);
                    break;
                case "cis":
                    input.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                    break;
                case "dis":
                    input.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                    break;
                case "e2":
                    input.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                    break;
                default:
                    //Just do nothing
                    break;
            } 
        }

        private void StopPlayingTone(String tone)
        {
            switch (tone)
            {
                case "e1":
                    input.Keyboard.KeyUp(VirtualKeyCode.VK_1);
                    break;
                case "fis":
                    input.Keyboard.KeyUp(VirtualKeyCode.VK_2);
                    break;
                case "gis":
                    input.Keyboard.KeyUp(VirtualKeyCode.VK_3);
                    break;
                case "a":
                    input.Keyboard.KeyUp(VirtualKeyCode.VK_4);
                    break;
                case "h":
                    input.Keyboard.KeyUp(VirtualKeyCode.VK_5);
                    break;
                case "cis":
                    input.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                    break;
                case "dis":
                    input.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                    break;
                case "e2":
                    input.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                    break;
                default:
                    //Just do nothing
                    break;
            }
        }

        private int GetBeatDurationMS(MusicScore score)
        {
            return (int)((60F / score.bpm) * 1000F);
        }

        private void SetInitialOctaveBlue()
        {
            //Start at blue octave
            //Go all the way down to make sure we're blue
            for (int i = 0; i < 3; i++)
            {
                OctaveDown();
            }
        }

        public void PlayScore(MusicScore score, int startDelayMS, bool looping)
        {
            Thread playerThread = new Thread(() => {
                //Don't start playing if already playing
                if (playing)
                {
                    return;
                }
                //Play the tune
                Task.Delay(startDelayMS).ContinueWith(t =>
                {
                    SetInitialOctaveBlue();
                    //Start playing the score
                    PlayScoreInternal(0, score, Octave.BLUE, GetBeatDurationMS(score), looping);
                });
            });
            playerThread.Start();
        }

        private void PlayScoreInternal(int beatIndex, MusicScore score, Octave currentOctave, int milisPerBeat, bool looping)
        {

            //Set playing
            if (!playing)
            {
                playing = true;
                this.playingStarted?.Invoke(this, null);
            }

            //Get score length
            int scoreLength = score.beats.Count;

            if (beatIndex < scoreLength && !stopPlaying)
            {
                MusicBeat currentBeat = score.beats[beatIndex];

                //Handle the octave swap
                if(!currentBeat.octave.Equals(currentOctave))
                {
                    Tuple<Octave, Octave> transition = new Tuple<Octave, Octave>(currentOctave, currentBeat.octave);
                    int transitionKeyStrokes = octaveChanges[transition];
                    if(transitionKeyStrokes < 0)
                    {
                        for(int i = 0; i < Math.Abs(transitionKeyStrokes); i++)
                        {
                            OctaveDown();
                        }
                    }
                    else
                    {
                        for(int i = 0; i < transitionKeyStrokes; i++)
                        {
                            OctaveUp();
                        }
                    }
                }

                //Play the tunes
                foreach(PropertyInfo propInfo in currentBeat.noteDurations.GetType().GetProperties())
                {
                    int noteDuration = (int)propInfo.GetValue(currentBeat.noteDurations);
                    if(noteDuration > 0)
                    {
                        //Play the tone
                        StartPlayingTone(propInfo.Name);
                        //Delay the keyup by the appropriate amount
                        Task.Delay(milisPerBeat * noteDuration - 20).ContinueWith(t => {
                            StopPlayingTone(propInfo.Name);
                        });
                    }
                }

                //Delay the next call by a beat duration + 20ms
                //The 20ms ensure a min of 20ms elapsed between key release and pressing it again
                //Meaning the key will register as a different keypress
                Task.Delay(milisPerBeat).ContinueWith(t =>
                {
                    PlayScoreInternal(++beatIndex, score, currentBeat.octave, milisPerBeat, looping);
                });
            }
            else
            {
                //If we didn't reach here due to an explicit stop, and we're looping, start playing again from 0
                if (!stopPlaying && looping)
                {
                    
                    PlayScoreInternal(0, score, currentOctave, milisPerBeat, looping);
                    //End this loop here
                    return;
                }
                //Stop playing
                playing = false;
                stopPlaying = false;
                playingStopped?.Invoke(this, null);
            }
        }

        public void StopPlaying()
        {
            if (this.playing)
            {
                this.stopPlaying = true;
            }
        }

    }
}
