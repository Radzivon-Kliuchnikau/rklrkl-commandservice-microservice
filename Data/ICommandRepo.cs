using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        // Platforms methods
        IEnumerable<Platform> GetAllPlatforms();

        void CreatePlatform(Platform platform);

        bool PlatformExists(int platformId);

        bool ExternalPlatformExists(int externalPlatformId);

        // Commands methods
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command? GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);

    }
}