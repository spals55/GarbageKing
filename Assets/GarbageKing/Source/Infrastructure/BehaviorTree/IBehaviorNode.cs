
    public interface IBehaviorNode : IReadOnlyBehaviorNode
    {
        BehaviorNodeStatus Execute(float time);

        void Reset();
    }

