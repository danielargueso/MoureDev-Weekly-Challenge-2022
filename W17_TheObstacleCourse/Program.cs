using System;
using System.Collections.Generic;
using System.Linq;

namespace W17_TheObstacleCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TrackObject> trackObjects = new()
            {
                TrackObject.Floor,
                TrackObject.Floor,
                TrackObject.Floor,
                TrackObject.Fence,
                TrackObject.Floor,
                TrackObject.Floor,
                TrackObject.Fence,
                TrackObject.Floor,
                TrackObject.Floor,
            };
            List<ActionType> actions = new()
            {
                ActionType.Run,
                ActionType.Jump,
                ActionType.Run,
                ActionType.Run,
                ActionType.Run,
                ActionType.Jump,
                ActionType.Jump,
                ActionType.Run,
                ActionType.Run,
            };

            
            var track = string.Join("", trackObjects);

            Console.WriteLine($"Track: {track}");

            var result = FinishedOK(actions, track);

            Console.WriteLine($"Result: {result}");
        }
        static bool FinishedOK(List<ActionType> actions, string track)
        {
            bool raceResult = true;
            string trackPerformed = string.Empty;
            string athleteActions = string.Empty;

            var splittedTrack = track.ToArray();

            if (actions.Count < splittedTrack.Length)
            {
                for (int i = actions.Count-1; i < splittedTrack.Length; i++)
                {
                    actions.Add(ActionType.DefaultAction);
                }
            }

            for (int trackPosition = 0; trackPosition < splittedTrack.Length; trackPosition++)
            {
                var athleteAction = actions[trackPosition];
                var trackStep = TrackObject.FromChar(splittedTrack[trackPosition]);
                var athleteCompleteStepSuccesfully = trackStep.ValidateAction(athleteAction);
                athleteActions += athleteAction.Name[0];

                if (athleteCompleteStepSuccesfully == false)
                {
                    splittedTrack[trackPosition] = trackStep.ErrorValue;
                    trackPerformed += trackStep.ErrorValue.ToString();
                    
                    raceResult = false;
                }
                else
                {
                    trackPerformed += trackStep.Value;
                }
                
            }

            Console.WriteLine($"Track Performed: {trackPerformed}");
            Console.WriteLine($"Athlete Actions: {athleteActions}");
            return raceResult;
        }
    }
}
