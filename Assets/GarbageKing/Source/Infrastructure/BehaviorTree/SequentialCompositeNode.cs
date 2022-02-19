using System;

public abstract class SequentialCompositeNode : BehaviorNode
{
    private readonly IBehaviorNode[] _childNodes;
    private readonly bool _alwaysReevaluate;

    public SequentialCompositeNode(IBehaviorNode[] childNodes, bool alwaysReevaluate)
    {
        _childNodes = childNodes;
        _alwaysReevaluate = alwaysReevaluate;
    }

    protected abstract BehaviorNodeStatus ContinueStatus { get; }

    protected int RunningChildIndex => Array.FindIndex(_childNodes,
        (childNode) => childNode.Status == BehaviorNodeStatus.Running);

    public override BehaviorNodeStatus OnExecute(float time)
    {
        int runningChildIndex = RunningChildIndex;

        for (int childIterator = _alwaysReevaluate || runningChildIndex == -1 ? 0 : runningChildIndex;
            childIterator < _childNodes.Length; childIterator += 1)
        {
            BehaviorNodeStatus childNodeStatus = _childNodes[childIterator].Execute(time);

            if (childNodeStatus != ContinueStatus)
            {
                for (int childToResetIterator = childIterator + 1;
                    childToResetIterator <= runningChildIndex; childToResetIterator += 1)
                    _childNodes[childToResetIterator].Reset();

                return childNodeStatus;
            }
        }

        return ContinueStatus;
    }

    public override void Reset()
    {
        base.Reset();

        foreach (IBehaviorNode child in _childNodes)
            child.Reset();
    }
}