
    public interface IBehaviorNode : IReadOnlyBehaviorNode
    {
        BehaviorNodeStatus Execute(long time);

        void Reset();
    }

