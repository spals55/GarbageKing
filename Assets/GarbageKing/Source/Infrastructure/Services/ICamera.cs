namespace PixupGames.Infrastracture.Services
{
    public interface ICamera
    {
        void Follow();
        void SetTarget(ICameraTarget target);
    }
}