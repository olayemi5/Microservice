using CommandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {

        //Platform
        bool SaveChanges();
        IEnumerable<Platform> GetPlatforms();
        void CreatePlatform(Platform plat);
        bool PlatformExists(int platformId);


        //Commands
        IEnumerable<Command> GetCommandForPlatform(int platformId);
        Command GetCommand(int commandId);
        void CreateCommand(int platformId, Command command)
    }
}