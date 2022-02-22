public interface IPlayer
{
    void Init(IInputDevice inputDevice, ICharacter character);
    ICharacter ControlledCharacter { get; }
}
