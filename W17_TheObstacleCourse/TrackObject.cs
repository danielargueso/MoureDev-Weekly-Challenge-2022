using System;
namespace W17_TheObstacleCourse
{
    public class TrackObject
    {
        public static TrackObject Floor => new(value:'_', errorValue:'x', validAction: ActionType.Run);
        public static TrackObject Fence => new(value:'|', errorValue:'/', validAction: ActionType.Jump);

        public char Value { get; set; }
        public char ErrorValue { get; set; }
        public ActionType ValidAction { get; set; }

        public TrackObject(char value, char errorValue, ActionType validAction)
        {
            Value = value;
            ErrorValue = errorValue;
            ValidAction = validAction;
        }

        public override bool Equals(object obj)
        {
            return obj is TrackObject @object &&
                   ErrorValue == @object.ErrorValue &&
                   Value == @object.Value &&
                   ValidAction == @object.ValidAction;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, ErrorValue, ValidAction);
        }

        public bool ValidateAction(ActionType actionType)
            => (actionType.Equals(ValidAction));

        public static TrackObject FromChar(char value)
        {
            if (Floor.Value.Equals(value))
            {
                return Floor;
            }

            if (Fence.Value.Equals(value))
            {
                return Fence;
            }

            //Default
            throw new ArgumentException("Argument value invalid", nameof(value));
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
