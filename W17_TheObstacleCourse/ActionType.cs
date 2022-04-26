namespace W17_TheObstacleCourse
{
    public class ActionType
    {
        public static ActionType Run => new("run");
        public static ActionType Jump => new("jump");

        public static ActionType DefaultAction => Run;

        public string Name { get; set; }

        public ActionType(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name; 
        }

        public override bool Equals(object obj)
        {
            return obj is ActionType type &&
                   Name == type.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
