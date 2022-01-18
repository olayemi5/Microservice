using CommandService.Models;

namespace CommandService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext context;

        public CommandRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            command.PlatformId = platformId;
            context.Commands.Add(command);
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat != null)
            {
                context.Platforms.Add(plat);
            }
            else
            {
                throw new ArgumentNullException(nameof(plat));
            }
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return (context.Platforms.Any(p => p.ExternalId == externalPlatformId));
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return context.Commands
                    .Where(c => c.PlatformId == platformId && c.Id == commandId)
                    .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandForPlatform(int platformId)
        {
            return context.Commands
                    .Where(c => c.PlatformId == platformId)
                    .OrderBy(c => c.Platform.Name);
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return context.Platforms.ToList();
        }

        public bool PlatformExists(int platformId)
        {
            return (context.Platforms.Any(p => p.Id == platformId));
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() > 0);
        }
    }
}