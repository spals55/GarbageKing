
    public abstract class BehaviorNode : IBehaviorNode
    {
        public BehaviorNodeStatus Status { get; protected set; }

        public bool Finished => Status == BehaviorNodeStatus.Failure;

        public bool Started => Status != BehaviorNodeStatus.Idle;

        public BehaviorNodeStatus Execute(float time)
        {
            Status = OnExecute(time);
            return Status;
        }

        public abstract BehaviorNodeStatus OnExecute(float time);

        public virtual void Reset()
        {
            Status = BehaviorNodeStatus.Idle;
        }
    }

